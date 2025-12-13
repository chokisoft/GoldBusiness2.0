using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class SubGrupoCuenta
    {
        public SubGrupoCuenta()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Código")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "StringLengthObligatory")]
        [RegularExpression(@"^\(?([0-9]{5})$", ErrorMessage = "No es valido el código")]
        public string Codigo { get; set; } = string.Empty;
        [Display(Name = "Grupo Cuenta")]
        public int GrupoCuenta { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;
        public bool Deudora { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        [Display(Name = "Grupo Cuenta")]
        public virtual GrupoCuenta GrupoCuentaNavigation { get; set; } = new GrupoCuenta();
        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
