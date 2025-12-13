using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class Configuracion
    {
        public Configuracion()
        {
            Establecimiento = new HashSet<Establecimiento>();
        }

        public int Id { get; set; }
        public string CodigoSistema { get; set; } = string.Empty;
        [Required]
        public string Licencia { get; set; } = string.Empty;
        public string NombreNegocio { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string CodPostal { get; set; } = string.Empty;
        public byte[] Imagen { get; set; } = Array.Empty<byte>();
        [Url]
        public string Web { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{4})$", ErrorMessage = "No es número valido de teléfono")]
        public string Telefono { get; set; } = string.Empty;
        public int CuentaPagar { get; set; }
        public int CuentaCobrar { get; set; }
        [Display(Name = "Caduca")]
        public DateTime Caducidad { get; set; }

        public virtual Cuenta CuentaCobrarNavigation { get; set; } = new Cuenta();
        public virtual Cuenta CuentaPagarNavigation { get; set; } = new Cuenta();
        public virtual ICollection<Establecimiento> Establecimiento { get; set; }
    }
}
