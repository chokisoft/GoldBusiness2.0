using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class ComprobanteTemporal
    {
        public int Id { get; set; }
        public int Establecimiento { get; set; }
        public string CodigoTransaccion { get; set; } = string.Empty;
        public string Transaccion { get; set; } = string.Empty;
        public string NoDocumento { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Cuenta { get; set; } = string.Empty;
        public string Departamento { get; set; } = string.Empty;
        public bool Inventario { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal? Debito { get; set; }
        public decimal? Credito { get; set; }
        public decimal? Parcial { get; set; }

        [Display(Name = "Establecimiento")]
        public virtual Establecimiento EstablecimientoNavigation { get; set; } = new Establecimiento();
    }
}
