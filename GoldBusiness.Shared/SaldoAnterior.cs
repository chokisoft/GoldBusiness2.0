namespace GoldBusiness.Shared
{
    public partial class SaldoAnterior
    {
        public int Id { get; set; }
        public int Localidad { get; set; }
        public int Producto { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal Existencia { get; set; }
        public decimal ImporteCosto { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Localidad LocalidadNavigation { get; set; } = new Localidad();
        public virtual Producto ProductoNavigation { get; set; } = new Producto();

    }
}
