using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class SubLinea
    {
        public SubLinea()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Código")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "StringLengthObligatory")]
        public string Codigo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;
        public int Linea { get; set; }
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual Linea LineaNavigation { get; set; } = new Linea();
        public virtual ICollection<Producto> Producto { get; set; } = new HashSet<Producto>();
    }
}
