using System;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using FarmaciaSalud.DataAccess;

namespace FarmaciaSalud.Services
{
    public static class AuthService
    {
        private const int ITERATIONS = 100000;
        private const int SALT_BYTES = 16;
        private const int HASH_BYTES = 32;

        public static (byte[] hash, byte[] salt) CreateHash(string password)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var salt = new byte[SALT_BYTES];
                rng.GetBytes(salt);

                var hash = PBKDF2(password, salt, ITERATIONS, HASH_BYTES);

                return (hash, salt);
            }
        }

        public static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (var derive = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                return derive.GetBytes(outputBytes);
            }
        }

        // 🔒 Comparación segura compatible con .NET Framework (reemplazo de CryptographicOperations)
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];

            return diff == 0;
        }

        public static (int EmpleadoID, string Puesto) LoginAndGetRole(string usuario, string password)
        {
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand("sp_GetEmpleadoHash", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);

                conn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return (0, null);

                    var salt = dr["PasswordSalt"] as byte[];
                    var storedHash = dr["PasswordHash"] as byte[];
                    if (salt == null || storedHash == null)
                    {
                        // log intento
                        return (0, null);
                    }
                    var empleadoId = Convert.ToInt32(dr["EmpleadoID"]);
                    var puesto = dr["Puesto"].ToString();


                    // Derivar hash
                    var derived = PBKDF2(password, salt, ITERATIONS, HASH_BYTES);

                    // Comparación segura ✔
                    bool equal = SlowEquals(storedHash, derived);

                    if (equal)
                    {
                        // Log de éxito
                        using (var cmd2 = new SqlCommand(
                            "INSERT INTO dbo.AuditLog (Usuario, Accion, Tabla, Detalle) VALUES (@u,'LOGIN_SUCCESS','Empleado',@d)", conn))
                        {
                            cmd2.Parameters.AddWithValue("@u", usuario);
                            cmd2.Parameters.AddWithValue("@d", "EmpleadoID=" + empleadoId);
                            cmd2.ExecuteNonQuery();
                        }

                        return (empleadoId, puesto);
                    }
                    else
                    {
                        // Log de fallo
                        using (var cmd2 = new SqlCommand(
                            "INSERT INTO dbo.AuditLog (Usuario, Accion, Tabla, Detalle) VALUES (@u,'LOGIN_FAILED','Empleado','Password mismatch')", conn))
                        {
                            cmd2.Parameters.AddWithValue("@u", usuario);
                            cmd2.ExecuteNonQuery();
                        }

                        return (0, null);
                    }
                }
            }

        }
    }
}

