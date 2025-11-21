using System;

namespace FarmaciaSalud.Models
{
    public class Medicamento
    {
        public int MedicamentoID { get; set; }
        public string CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public string PrincipioActivo { get; set; }
        public char Tipo { get; set; }

        public int? CategoriaID { get; set; }
        public string CategoriaNombre { get; set; }

        public int? ProveedorID { get; set; }
        public string ProveedorNombre { get; set; }

        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }

        public bool Activo { get; set; }
        public DateTime? FechaCaducidad { get; set; }
    }
}
