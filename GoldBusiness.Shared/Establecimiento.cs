using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class Establecimiento
    {
        public Establecimiento()
        {
            Comprobante = new HashSet<Comprobante>();
            ComprobanteTemporal = new HashSet<ComprobanteTemporal>();
            CuentaCobrarPagar = new HashSet<CuentaCobrarPagar>();
            EstadoCuenta = new HashSet<EstadoCuenta>();
            Localidad = new HashSet<Localidad>();
            Moneda = new HashSet<Moneda>();
            OperacionesEncabezado = new HashSet<OperacionesEncabezado>();
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public int Negocio { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Código")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "StringLengthObligatory")]
        public string Codigo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        [Display(Name = "Negocio")]
        public virtual Configuracion NegocioNavigation { get; set; } = new Configuracion();
        public virtual ICollection<Comprobante> Comprobante { get; set; }
        public virtual ICollection<ComprobanteTemporal> ComprobanteTemporal { get; set; }
        public virtual ICollection<CuentaCobrarPagar> CuentaCobrarPagar { get; set; }
        public virtual ICollection<EstadoCuenta> EstadoCuenta { get; set; }
        public virtual ICollection<Localidad> Localidad { get; set; }
        public virtual ICollection<Moneda> Moneda { get; set; }
        public virtual ICollection<OperacionesEncabezado> OperacionesEncabezado { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
