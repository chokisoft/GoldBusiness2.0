using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class OperacionesEncabezado
    {
        public OperacionesEncabezado()
        {
            OperacionesDetalle = new HashSet<OperacionesDetalle>();
        }

        public int Id { get; set; }
        public int Establecimiento { get; set; }
        public int Transaccion { get; set; }
        public string NoDocumento { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; }
        public int? Proveedor { get; set; }
        public int? Cliente { get; set; }
        public string NoPrimario { get; set; } = string.Empty;
        public int? Referencia { get; set; }
        public int? ConceptoAjuste { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public bool Efectivo { get; set; }
        public bool Contabilizada { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual Cliente ClienteNavigation { get; set; } = new Cliente();
        public virtual ConceptoAjuste ConceptoAjusteNavigation { get; set; } = new ConceptoAjuste();
        public virtual Establecimiento EstablecimientoNavigation { get; set; } = new Establecimiento();
        public virtual Proveedor ProveedorNavigation { get; set; } = new Proveedor();
        public virtual Transaccion TransaccionNavigation { get; set; } = new Transaccion();
        public virtual ICollection<OperacionesDetalle> OperacionesDetalle { get; set; }
    }
}
