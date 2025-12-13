namespace GoldBusiness.Shared
{
    public partial class CajaRegistradoraDetalle
    {
        public int Id { get; set; }
        public int CajaRegistradora { get; set; }
        public int Localidad { get; set; }
        public int Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Venta { get; set; }
        public decimal ImporteVenta { get; set; }

        public virtual CajaRegistradora CajaRegistradoraNavigation { get; set; } = new CajaRegistradora();
    }
}
