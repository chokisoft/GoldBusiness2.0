namespace GoldBusiness.Shared
{
    public partial class FichaProducto
    {
        public int Id { get; set; }
        public int Producto { get; set; }
        public int Localidad { get; set; }
        public int Codigo { get; set; }
        public decimal Cantidad { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual Producto CodigoNavigation { get; set; } = new Producto();
        public virtual Localidad LocalidadNavigation { get; set; } = new Localidad();
        public virtual Producto ProductoNavigation { get; set; } = new Producto();
    }
}
