using Microsoft.AspNetCore.Identity;

namespace GoldBusiness.Shared
{
    public class ApplicationUser : IdentityUser
    {
        // Solo las propiedades más esenciales para empezar
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; } = true;

        // Las demás propiedades las agregaremos después
        // public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // public DateTime? LastLoginAt { get; set; }
        // ... etc
    }
}