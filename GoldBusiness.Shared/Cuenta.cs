using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            ComprobanteDetalle = new HashSet<ComprobanteDetalle>();
            ConceptoAjuste = new HashSet<ConceptoAjuste>();
            ConfiguracionCuentaCobrarNavigation = new HashSet<Configuracion>();
            ConfiguracionCuentaPagarNavigation = new HashSet<Configuracion>();
            CuentaCobrarPagarCuentaCobroEfectivoNavigation = new HashSet<CuentaCobrarPagar>();
            CuentaCobrarPagarCuentaCobroElectronicoNavigation = new HashSet<CuentaCobrarPagar>();
            CuentaCobrarPagarCuentaPagoEfectivoNavigation = new HashSet<CuentaCobrarPagar>();
            CuentaCobrarPagarCuentaPagoElectronicoNavigation = new HashSet<CuentaCobrarPagar>();
            EstadoCuenta = new HashSet<EstadoCuenta>();
            LocalidadCuentaCostoNavigation = new HashSet<Localidad>();
            LocalidadCuentaDevolucionNavigation = new HashSet<Localidad>();
            LocalidadCuentaInventarioNavigation = new HashSet<Localidad>();
            LocalidadCuentaVentaNavigation = new HashSet<Localidad>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Código")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "StringLengthObligatory")]
        [RegularExpression(@"^\(?([0-9]{8})$", ErrorMessage = "No es valido el código")]
        public string Codigo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;
        [Display(Name = "SubGrupo Cuenta")]
        public int SubGrupoCuenta { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        [Display(Name = "SubGrupo Cuenta")]
        public virtual SubGrupoCuenta SubGrupoCuentaNavigation { get; set; } = new SubGrupoCuenta();
        public virtual ICollection<ComprobanteDetalle> ComprobanteDetalle { get; set; }
        public virtual ICollection<ConceptoAjuste> ConceptoAjuste { get; set; }
        public virtual ICollection<Configuracion> ConfiguracionCuentaCobrarNavigation { get; set; }
        public virtual ICollection<Configuracion> ConfiguracionCuentaPagarNavigation { get; set; }
        public virtual ICollection<CuentaCobrarPagar> CuentaCobrarPagarCuentaCobroEfectivoNavigation { get; set; }
        public virtual ICollection<CuentaCobrarPagar> CuentaCobrarPagarCuentaCobroElectronicoNavigation { get; set; }
        public virtual ICollection<CuentaCobrarPagar> CuentaCobrarPagarCuentaPagoEfectivoNavigation { get; set; }
        public virtual ICollection<CuentaCobrarPagar> CuentaCobrarPagarCuentaPagoElectronicoNavigation { get; set; }
        public virtual ICollection<EstadoCuenta> EstadoCuenta { get; set; }
        public virtual ICollection<Localidad> LocalidadCuentaCostoNavigation { get; set; }
        public virtual ICollection<Localidad> LocalidadCuentaDevolucionNavigation { get; set; }
        public virtual ICollection<Localidad> LocalidadCuentaInventarioNavigation { get; set; }
        public virtual ICollection<Localidad> LocalidadCuentaVentaNavigation { get; set; }
    }
}
