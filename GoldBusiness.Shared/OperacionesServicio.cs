using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class OperacionesServicio
    {
        public int Id { get; set; }
        public int OperacionesDetalle { get; set; }
        public int Localidad { get; set; }
        public int Codigo { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Cantidad { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Costo { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal ImporteCosto { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual OperacionesDetalle OperacionesDetalleNavigation { get; set; } = new OperacionesDetalle();
    }
}
