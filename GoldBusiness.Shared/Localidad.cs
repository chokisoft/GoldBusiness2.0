using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class Localidad
    {
        public Localidad()
        {
            ErroresVenta = new HashSet<ErroresVenta>();
            FichaProducto = new HashSet<FichaProducto>();
            OperacionesDetalle = new HashSet<OperacionesDetalle>();
            Saldo = new HashSet<Saldo>();
            SaldoAnterior = new HashSet<SaldoAnterior>();
        }

        public int Id { get; set; }
        public int Establecimiento { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Código")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "StringLengthObligatory")]
        public string Codigo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;
        public bool Almacen { get; set; }
        public int CuentaInventario { get; set; }
        public int CuentaCosto { get; set; }
        public int CuentaVenta { get; set; }
        public int CuentaDevolucion { get; set; }
        public bool Activo { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual Cuenta CuentaCostoNavigation { get; set; } = new Cuenta();
        public virtual Cuenta CuentaDevolucionNavigation { get; set; } = new Cuenta();
        public virtual Cuenta CuentaInventarioNavigation { get; set; } = new Cuenta();
        public virtual Cuenta CuentaVentaNavigation { get; set; } = new Cuenta();
        public virtual Establecimiento EstablecimientoNavigation { get; set; } = new Establecimiento();
        public virtual ICollection<ErroresVenta> ErroresVenta { get; set; }
        public virtual ICollection<FichaProducto> FichaProducto { get; set; }
        public virtual ICollection<OperacionesDetalle> OperacionesDetalle { get; set; }
        public virtual ICollection<Saldo> Saldo { get; set; }
        public virtual ICollection<SaldoAnterior> SaldoAnterior { get; set; }
    }
}
