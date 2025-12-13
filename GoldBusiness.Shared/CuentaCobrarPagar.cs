using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class CuentaCobrarPagar
    {
        public int Id { get; set; }
        public int Establecimiento { get; set; }
        public int Transaccion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; }
        public int? Proveedor { get; set; }
        public int? Cliente { get; set; }
        public string NoPrimario { get; set; } = string.Empty;
        public string NoDocumento { get; set; } = string.Empty;
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Importe { get; set; }
        public int? CuentaPagoEfectivo { get; set; }
        public string PagoEfectivoDepartamento { get; set; } = string.Empty;
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? PagoEfectivoImporte { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? PagoEfectivoParcialMlc { get; set; }
        public int? CuentaPagoElectronico { get; set; }
        public string PagoElectronicoDepartamento { get; set; } = string.Empty;
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? PagoElectronicoImporte { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? PagoElectronicoParcialMlc { get; set; }
        public int? CuentaCobroEfectivo { get; set; }
        public string CobroEfectivoDepartamento { get; set; } = string.Empty;
        public decimal? CobroEfectivoImporte { get; set; }
        public decimal? CobroEfectivoParcialMlc { get; set; }
        public int? CuentaCobroElectronico { get; set; }
        public string CobroElectronicoDepartamento { get; set; } = string.Empty;
        public decimal? CobroElectronicoImporte { get; set; }
        public decimal? CobroElectronicoParcialMlc { get; set; }
        public bool Contabilizada { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual Cliente ClienteNavigation { get; set; } = new Cliente();
        public virtual Cuenta CuentaCobroEfectivoNavigation { get; set; } = new Cuenta();
        public virtual Cuenta CuentaCobroElectronicoNavigation { get; set; } = new Cuenta();
        public virtual Cuenta CuentaPagoEfectivoNavigation { get; set; } = new Cuenta();
        public virtual Cuenta CuentaPagoElectronicoNavigation { get; set; } = new Cuenta();
        public virtual Establecimiento EstablecimientoNavigation { get; set; } = new Establecimiento();
        public virtual Proveedor ProveedorNavigation { get; set; } = new Proveedor();
        public virtual Transaccion TransaccionNavigation { get; set; } = new Transaccion();
    }
}
