using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class UnidadMedida
    {
        public UnidadMedida()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Código")]
        [StringLength(3)]
        public string Codigo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }

    }
}
