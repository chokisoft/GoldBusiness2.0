namespace GoldBusiness.Shared.DTOs
{
    public class CuentaDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // Relación con GrupoCuenta
        public string GrupoCuentaDescripcion { get; set; } = string.Empty;

        // Relación con SubGrupoCuenta
        public int SubGrupoCuenta { get; set; }
        public string SubGrupoCuentaDescripcion { get; set; } = string.Empty;

        public bool Cancelado { get; set; }

        // Trazabilidad
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }
    }
}