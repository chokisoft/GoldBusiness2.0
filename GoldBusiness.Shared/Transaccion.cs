namespace GoldBusiness.Shared
{
    public partial class Transaccion
    {
        public Transaccion()
        {
            CuentaCobrarPagar = new HashSet<CuentaCobrarPagar>();
            OperacionesEncabezado = new HashSet<OperacionesEncabezado>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public virtual ICollection<CuentaCobrarPagar> CuentaCobrarPagar { get; set; }
        public virtual ICollection<OperacionesEncabezado> OperacionesEncabezado { get; set; }
    }
}
