namespace GoldBusiness.Shared
{
    public partial class IdTurno
    {
        public IdTurno()
        {
            CajaRegistradora = new HashSet<CajaRegistradora>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cajero { get; set; } = string.Empty;
        public DateTime Inicio { get; set; }
        public decimal? Fondo { get; set; }
        public decimal? Extraccion { get; set; }
        public DateTime? Cierre { get; set; }

        public virtual ICollection<CajaRegistradora> CajaRegistradora { get; set; }
    }
}
