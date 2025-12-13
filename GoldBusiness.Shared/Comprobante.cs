using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class Comprobante
    {
        public Comprobante()
        {
            ComprobanteDetalle = new HashSet<ComprobanteDetalle>();
        }

        public int Id { get; set; }
        public int Establecimiento { get; set; }
        public string NoComprobante { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public bool Automatico { get; set; }
        public bool Posteado { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual Establecimiento EstablecimientoNavigation { get; set; } = new Establecimiento();
        public virtual ICollection<ComprobanteDetalle> ComprobanteDetalle { get; set; }
    }
}
