using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class GrupoCuenta
    {
        public GrupoCuenta()
        {
            SubGrupoCuenta = new HashSet<SubGrupoCuenta>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Código")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "StringLengthObligatory")]
        [RegularExpression(@"^\(?([0-9]{2})$", ErrorMessage = "No es valido el código")]
        public string Codigo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual ICollection<SubGrupoCuenta> SubGrupoCuenta { get; set; }
    }
}
