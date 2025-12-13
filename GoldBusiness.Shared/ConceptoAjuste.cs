namespace GoldBusiness.Shared
{
    public partial class ConceptoAjuste
    {
        public ConceptoAjuste()
        {
            OperacionesEncabezado = new HashSet<OperacionesEncabezado>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int Cuenta { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual Cuenta CuentaNavigation { get; set; } = new Cuenta();
        public virtual ICollection<OperacionesEncabezado> OperacionesEncabezado { get; set; }
    }
}
