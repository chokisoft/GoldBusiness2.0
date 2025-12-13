using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class ComprobanteDetalle
    {
        public int Id { get; set; }
        public int Comprobante { get; set; }
        public int Cuenta { get; set; }
        public string Departamento { get; set; } = string.Empty;
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Debito { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Credito { get; set; }
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Parcial { get; set; }
        public string Nota { get; set; } = string.Empty;
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual Comprobante ComprobanteNavigation { get; set; } = new Comprobante();
        public virtual Cuenta CuentaNavigation { get; set; } = new Cuenta();
    }
}