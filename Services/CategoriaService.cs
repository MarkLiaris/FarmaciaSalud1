using FarmaciaSalud.DataAccess;
using FarmaciaSalud.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FarmaciaSalud.Services
{
    public static class CategoriaService
    {
        public static List<Categoria> Listar()
        {
            var lista = new List<Categoria>();
            DataTable dt = SqlHelper.ExecuteDataTable("sp_Categoria_Listar");

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Categoria
                {
                    CategoriaID = (int)row["CategoriaID"],
                    Nombre = row["Nombre"].ToString(),
                    Descripcion = row["Descripcion"].ToString()
                });
            }

            return lista;
        }

        public static void Insertar(string nombre, string descripcion)
        {
            SqlHelper.ExecuteNonQuery("sp_Categoria_Insertar",
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Descripcion", descripcion)
            );
        }

        public static void Actualizar(int id, string nombre, string descripcion)
        {
            SqlHelper.ExecuteNonQuery("sp_Categoria_Actualizar",
                new SqlParameter("@CategoriaID", id),
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Descripcion", descripcion)
            );
        }

        public static void Eliminar(int id)
        {
            SqlHelper.ExecuteNonQuery("sp_Categoria_Eliminar",
                new SqlParameter("@CategoriaID", id)
            );
        }
    }
}
