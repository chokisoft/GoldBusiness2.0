namespace GoldBusiness.Shared.DTOs
{
    public class SubGrupoCuentaDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public int GrupoCuenta { get; set; }
        public string GrupoCuentaDescripcion { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Deudora { get; set; }
        public bool Cancelado { get; set; }

        // Trazabilidad
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }
    }
}