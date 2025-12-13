namespace GoldBusiness.Shared
{
    public partial class CajaRegistradora
    {
        public CajaRegistradora()
        {
            CajaRegistradoraDetalle = new HashSet<CajaRegistradoraDetalle>();
        }

        public int Id { get; set; }
        public int IdTurno { get; set; }
        public int? Mesa { get; set; }
        public bool Cerrado { get; set; }

        public virtual IdTurno IdTurnoNavigation { get; set; } = new IdTurno();
        public virtual ICollection<CajaRegistradoraDetalle> CajaRegistradoraDetalle { get; set; }
    }
}
