namespace GoldBusiness.Shared
{
    public partial class EstadoCuenta
    {
        public int Id { get; set; }
        public int Establecimiento { get; set; }
        public int Cuenta { get; set; }
        public string Departamento { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public decimal Parcial { get; set; }

        public virtual Cuenta CuentaNavigation { get; set; } = new Cuenta();
        public virtual Establecimiento EstablecimientoNavigation { get; set; } = new Establecimiento();
    }
}
