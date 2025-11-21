using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FarmaciaSalud.DataAccess;

namespace FarmaciaSalud.Services
{
    public static class ProveedorService
    {
        public static List<dynamic> GetAll()
        {
            var dt = SqlHelper.ExecuteDataTable("sp_Proveedor_GetAll");
            var lista = new List<dynamic>();

            foreach (DataRow r in dt.Rows)
            {
                lista.Add(new
                {
                    Id = (int)r["ProveedorID"],
                    Nombre = r["RazonSocial"].ToString()
                });
            }

            return lista;
        }
    }
}
