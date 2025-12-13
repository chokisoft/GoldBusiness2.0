using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class Producto
    {
        public Producto()
        {
            ErroresVenta = new HashSet<ErroresVenta>();
            FichaProductoCodigoNavigation = new HashSet<FichaProducto>();
            FichaProductoProductoNavigation = new HashSet<FichaProducto>();
            OperacionesDetalle = new HashSet<OperacionesDetalle>();
            Saldo = new HashSet<Saldo>();
            SaldoAnterior = new HashSet<SaldoAnterior>();
        }

        public int Id { get; set; }
        public int Establecimiento { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Código")]
        [StringLength(13)]
        //[CodigoProducto(ErrorMessage = "No tiene la cantidad de digitos necesarios")]
        public string Codigo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;
        public int UnidadMedida { get; set; }
        public int Proveedor { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal PrecioVenta { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal PrecioCosto { get; set; }
        [Range(-0.01, 99.99, ErrorMessage = "Porciento entre -0.01 - 99.99")]
        public decimal Iva { get; set; }
        public string CodigoReferencia { get; set; } = string.Empty;
        public decimal StockMinimo { get; set; }
        public bool Servicio { get; set; }
        public int SubLinea { get; set; }
        public byte[] Imagen { get; set; } = Array.Empty<byte>();
        public string Caracteristicas { get; set; } = string.Empty;
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual Establecimiento EstablecimientoNavigation { get; set; } = new Establecimiento();
        public virtual Proveedor ProveedorNavigation { get; set; } = new Proveedor();
        public virtual SubLinea SubLineaNavigation { get; set; } = new SubLinea();
        public virtual UnidadMedida UnidadMedidaNavigation { get; set; } = new UnidadMedida();
        public virtual ICollection<ErroresVenta> ErroresVenta { get; set; }
        public virtual ICollection<FichaProducto> FichaProductoCodigoNavigation { get; set; }
        public virtual ICollection<FichaProducto> FichaProductoProductoNavigation { get; set; }
        public virtual ICollection<OperacionesDetalle> OperacionesDetalle { get; set; }
        public virtual ICollection<Saldo> Saldo { get; set; }
        public virtual ICollection<SaldoAnterior> SaldoAnterior { get; set; }

        public string CodigoDescripcion
        {
            get { return Codigo + " | " + Descripcion; }
        }

    }
}
