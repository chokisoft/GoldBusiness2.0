using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GoldBusiness.Shared
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public int UsernameChangeLimit { get; set; } = 3;
        public byte[] ProfilePicture { get; set; } = Array.Empty<byte>();
        [Required]
        public string Accesos { get; set; } = string.Empty;
        public bool ChangePassword { get; set; }
    }
}
