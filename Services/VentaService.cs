using System;
using System.Data;
using System.Data.SqlClient;
using FarmaciaSalud.DataAccess;

namespace FarmaciaSalud.Services
{
    public static class VentaService
    {
        // ----------------------------------------------------------
        // CREA EL TVP QUE RECIBE EL SP (ItemsVenta)
        // ----------------------------------------------------------
        public static DataTable CrearTablaItems()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MedicamentoID", typeof(int));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("PrecioUnitario", typeof(decimal));
            return dt;
        }

        // ----------------------------------------------------------
        // REGISTRA UNA VENTA COMPLETA
        // ----------------------------------------------------------
        public static int RegistrarVenta(
            int empleadoID,
            int? clienteID,
            string tipoPago,
            int? recetaID,
            DataTable items
        )
        {
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_RegisterVenta", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                    cmd.Parameters.AddWithValue("@ClienteID", (object)clienteID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TipoPago", tipoPago);
                    cmd.Parameters.AddWithValue("@RecetaID", (object)recetaID ?? DBNull.Value);

                    SqlParameter tvp = cmd.Parameters.AddWithValue("@Items", items);
                    tvp.SqlDbType = SqlDbType.Structured;
                    tvp.TypeName = "dbo.ItemsVenta";

                    SqlParameter pOut = new SqlParameter("@NuevaVentaID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(pOut);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (int)pOut.Value;
                }
            }
        }

        // ----------------------------------------------------------
        // LISTAR VENTAS
        // ----------------------------------------------------------
        public static DataTable ListarVentas()
        {
            return SqlHelper.ExecuteDataTable("sp_Venta_Listar");
        }

        // ----------------------------------------------------------
        // OBTENER DETALLE DE UNA VENTA
        // ----------------------------------------------------------
        public static DataTable ObtenerDetalle(int ventaID)
        {
            return SqlHelper.ExecuteDataTable("sp_Venta_Detalle",
                new SqlParameter("@VentaID", ventaID));
        }
    }
}
