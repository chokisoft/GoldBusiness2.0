using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class ErroresVenta
    {
        public int Id { get; set; }
        public int OperacionesDetalle { get; set; }
        public int Localidad { get; set; }
        public int Codigo { get; set; }
        public decimal Cantidad { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Costo { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal ImporteCosto { get; set; }
        public bool Servicio { get; set; }

        public virtual Producto CodigoNavigation { get; set; } = new Producto();
        public virtual Localidad LocalidadNavigation { get; set; } = new Localidad();
        public virtual OperacionesDetalle OperacionesDetalleNavigation { get; set; } = new OperacionesDetalle();

    }
}
