using System.Collections.Generic;
using System.Data;
using FarmaciaSalud.DataAccess;

namespace FarmaciaSalud.Services
{
    public static class CategoriaLookupService
    {
        public static List<dynamic> GetAll()
        {
            var dt = SqlHelper.ExecuteDataTable("sp_Categoria_Listar");
            var lista = new List<dynamic>();

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new
                {
                    Id = (int)row["CategoriaID"],
                    Nombre = row["Nombre"].ToString()
                });
            }

            return lista;
        }
    }
}
