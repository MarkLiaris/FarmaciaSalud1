using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FarmaciaSalud.DataAccess;
using FarmaciaSalud.Models;

namespace FarmaciaSalud.Services
{
    public static class MedicamentoService
    {
        public static List<Medicamento> GetAll()
        {
            var lista = new List<Medicamento>();
            DataTable dt = SqlHelper.ExecuteDataTable("sp_Medicamento_GetAll");
            foreach (DataRow r in dt.Rows)
                lista.Add(MapRow(r));
            return lista;
        }

        public static List<Medicamento> Search(string texto)
        {
            var lista = new List<Medicamento>();
            DataTable dt = SqlHelper.ExecuteDataTable("sp_Medicamento_Search",
                new SqlParameter("@Texto", texto));
            foreach (DataRow r in dt.Rows)
                lista.Add(MapRow(r));
            return lista;
        }

        public static Medicamento GetByBarcode(string codigo)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("sp_Medicamento_GetByBarcode",
                new SqlParameter("@CodigoBarra", codigo));

            if (dt.Rows.Count == 0)
                return null;

            return MapRow(dt.Rows[0]);
        }

        public static int Add(Medicamento m)
        {
            var pNuevo = new SqlParameter("@NuevoID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            SqlHelper.ExecuteNonQuery("sp_Medicamento_Add",
                new SqlParameter("@CodigoBarra", m.CodigoBarra),
                new SqlParameter("@Nombre", m.Nombre),
                new SqlParameter("@PrincipioActivo", (object)m.PrincipioActivo ?? DBNull.Value),
                new SqlParameter("@Tipo", m.Tipo),
                new SqlParameter("@CategoriaID", (object)m.CategoriaID ?? DBNull.Value),
                new SqlParameter("@ProveedorID", (object)m.ProveedorID ?? DBNull.Value),
                new SqlParameter("@PrecioCompra", m.PrecioCompra),
                new SqlParameter("@PrecioVenta", m.PrecioVenta),
                new SqlParameter("@Stock", m.Stock),
                new SqlParameter("@FechaCaducidad", (object)m.FechaCaducidad ?? DBNull.Value),
                pNuevo
            );

            return (int)pNuevo.Value;
        }

        public static void Update(Medicamento m)
        {
            SqlHelper.ExecuteNonQuery("sp_Medicamento_Update",
                new SqlParameter("@MedicamentoID", m.MedicamentoID),
                new SqlParameter("@CodigoBarra", m.CodigoBarra),
                new SqlParameter("@Nombre", m.Nombre),
                new SqlParameter("@PrincipioActivo", (object)m.PrincipioActivo ?? DBNull.Value),
                new SqlParameter("@Tipo", m.Tipo),
                new SqlParameter("@CategoriaID", (object)m.CategoriaID ?? DBNull.Value),
                new SqlParameter("@ProveedorID", (object)m.ProveedorID ?? DBNull.Value),
                new SqlParameter("@PrecioCompra", m.PrecioCompra),
                new SqlParameter("@PrecioVenta", m.PrecioVenta),
                new SqlParameter("@Stock", m.Stock),
                new SqlParameter("@FechaCaducidad", (object)m.FechaCaducidad ?? DBNull.Value),
                new SqlParameter("@Activo", m.Activo)
            );
        }

        public static void Delete(int id)
        {
            SqlHelper.ExecuteNonQuery("sp_Medicamento_Delete",
                new SqlParameter("@MedicamentoID", id));
        }

        private static Medicamento MapRow(DataRow r)
        {
            return new Medicamento
            {
                MedicamentoID = r.Field<int>("MedicamentoID"),
                CodigoBarra = r.Field<string>("CodigoBarra"),
                Nombre = r.Field<string>("Nombre"),
                PrincipioActivo = r.IsNull("PrincipioActivo") ? null : r.Field<string>("PrincipioActivo"),
                Tipo = string.IsNullOrEmpty(r.Field<string>("Tipo")) ? 'G' : r.Field<string>("Tipo")[0],
                PrecioCompra = r.Field<decimal>("PrecioCompra"),
                PrecioVenta = r.Field<decimal>("PrecioVenta"),
                Stock = r.Field<int>("Stock"),
                FechaCaducidad = r.IsNull("FechaCaducidad") ? (DateTime?)null : r.Field<DateTime>("FechaCaducidad"),
                Activo = r.Field<bool>("Activo"),
                CategoriaID = r.IsNull("CategoriaID") ? (int?)null : r.Field<int>("CategoriaID"),
                CategoriaNombre = r.IsNull("CategoriaNombre") ? null : r.Field<string>("CategoriaNombre"),
                ProveedorID = r.IsNull("ProveedorID") ? (int?)null : r.Field<int>("ProveedorID"),
                ProveedorNombre = r.IsNull("ProveedorNombre") ? null : r.Field<string>("ProveedorNombre")
            };
        }
    }
}