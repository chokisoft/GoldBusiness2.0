using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            CuentaCobrarPagar = new HashSet<CuentaCobrarPagar>();
            OperacionesEncabezado = new HashSet<OperacionesEncabezado>();
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
        [StringLength(11)]
        public string Nif { get; set; } = string.Empty;
        [StringLength(27)]
        public string Iban { get; set; } = string.Empty;
        [StringLength(11)]
        public string BicoSwift { get; set; } = string.Empty;
        [Range(-0.01, 99.99, ErrorMessage = "Porciento entre -0.01 - 99.99")]
        public decimal Iva { get; set; }
        [StringLength(256)]
        public string Direccion { get; set; } = string.Empty;
        [StringLength(50)]
        public string Municipio { get; set; } = string.Empty;
        [StringLength(50)]
        public string Provincia { get; set; } = string.Empty;
        [StringLength(5)]
        public string CodPostal { get; set; } = string.Empty;
        [StringLength(256)]
        [Url]
        public string Web { get; set; } = string.Empty;
        [StringLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email1 { get; set; } = string.Empty;
        [StringLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email2 { get; set; } = string.Empty;
        [StringLength(50)]
        [Phone]
        [RegularExpression(@"[0-9]{4}[-]{1}[0-9]{4}", ErrorMessage = "El número de teléfono debe ser ####-####")]
        public string Telefono1 { get; set; } = string.Empty;
        [StringLength(50)]
        [Phone]
        [RegularExpression(@"[0-9]{4}[-]{1}[0-9]{4}", ErrorMessage = "El número de teléfono debe ser ####-####")]
        public string Telefono2 { get; set; } = string.Empty;
        [StringLength(50)]
        public string Fax1 { get; set; } = string.Empty;
        [StringLength(50)]
        public string Fax2 { get; set; } = string.Empty;
        public bool Cancelado { get; set; }
        public string CreadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraCreado { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime FechaHoraModificado { get; set; }

        public virtual ICollection<CuentaCobrarPagar> CuentaCobrarPagar { get; set; }
        public virtual ICollection<OperacionesEncabezado> OperacionesEncabezado { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
