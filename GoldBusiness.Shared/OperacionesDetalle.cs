using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class OperacionesDetalle
    {
        public OperacionesDetalle()
        {
            ErroresVenta = new HashSet<ErroresVenta>();
            OperacionesServicio = new HashSet<OperacionesServicio>();
        }

        public int Id { get; set; }
        public int OperacionesEncabezado { get; set; }
        public int Localidad { get; set; }
        public int Codigo { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Cantidad { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Costo { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal ImporteCosto { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Venta { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal ImporteVenta { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Existencia { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual Producto CodigoNavigation { get; set; } = new Producto();
        public virtual Localidad LocalidadNavigation { get; set; } = new Localidad();
        public virtual OperacionesEncabezado OperacionEncabezadoNavigation { get; set; } = new OperacionesEncabezado();
        public virtual ICollection<ErroresVenta> ErroresVenta { get; set; }
        public virtual ICollection<OperacionesServicio> OperacionesServicio { get; set; }
    }
}
