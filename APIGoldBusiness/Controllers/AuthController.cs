using GoldBusiness.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIGoldBusiness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public record LoginRequest(string UserName, string Password);
        public record LoginResponse(string Token, DateTime Expires, string UserName, string Email, string[] Roles, string FullName);

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            try
            {
                // Buscar usuario por nombre de usuario o email
                var user = await _userManager.FindByNameAsync(model.UserName) ??
                           await _userManager.FindByEmailAsync(model.UserName);

                if (user == null)
                    return Unauthorized(new { message = "Invalid credentials" });

                // Verificar contraseña
                if (!await _userManager.CheckPasswordAsync(user, model.Password))
                    return Unauthorized(new { message = "Invalid credentials" });

                // Verificar si el usuario está activo
                if (!user.IsActive)
                    return Unauthorized(new { message = "Account is disabled" });

                // Obtener roles
                var roles = await _userManager.GetRolesAsync(user);

                // Configuración JWT
                var jwtSection = _config.GetSection("Jwt");
                var key = Encoding.UTF8.GetBytes(jwtSection["Key"] ?? throw new InvalidOperationException("Jwt:Key missing"));
                var expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSection["ExpireMinutes"] ?? "60"));

                // Crear claims
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                    new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                    new Claim("fullName", $"{user.FirstName} {user.LastName}".Trim()),
                    new Claim("firstName", user.FirstName ?? string.Empty),
                    new Claim("lastName", user.LastName ?? string.Empty),
                    new Claim("isActive", user.IsActive.ToString()),
                    new Claim("userId", user.Id)
                };

                // Agregar roles como claims
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                // Agregar claims personalizados del usuario
                var userClaims = await _userManager.GetClaimsAsync(user);
                claims.AddRange(userClaims);

                // Firmar token
                var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: jwtSection["Issuer"],
                    audience: jwtSection["Audience"],
                    claims: claims,
                    expires: expires,
                    signingCredentials: creds);

                var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

                // Actualizar último login
                await _userManager.UpdateAsync(user);

                // Respuesta
                return Ok(new LoginResponse(
                    Token: tokenStr,
                    Expires: expires,
                    UserName: user.UserName ?? string.Empty,
                    Email: user.Email ?? string.Empty,
                    Roles: roles.ToArray(),
                    FullName: $"{user.FirstName} {user.LastName}".Trim()
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during login", error = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            try
            {
                // Validar que las contraseñas coincidan
                if (model.Password != model.ConfirmPassword)
                    return BadRequest(new { message = "Passwords do not match" });

                // Verificar si el usuario ya existe
                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                    return BadRequest(new { message = "User with this email already exists" });

                // Crear nuevo usuario
                var user = new ApplicationUser
                {
                    UserName = model.Email, // Usar email como username
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    IsActive = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new { message = "Registration failed", errors });
                }

                // Asignar rol por defecto
                await _userManager.AddToRoleAsync(user, "User");

                return Ok(new
                {
                    message = "User registered successfully",
                    userId = user.Id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred during registration", error = ex.Message });
            }
        }

        [HttpGet("user-info")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    return Unauthorized();
                }

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound(new { message = "User not found." });
                }

                var roles = await _userManager.GetRolesAsync(user);
                var claims = await _userManager.GetClaimsAsync(user);

                return Ok(new
                {
                    userId = user.Id,
                    userName = user.UserName,
                    email = user.Email,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    fullName = $"{user.FirstName} {user.LastName}".Trim(),
                    phoneNumber = user.PhoneNumber,
                    isActive = user.IsActive,
                    roles = roles,
                    claims = claims.Select(c => new { c.Type, c.Value }),
                    emailConfirmed = user.EmailConfirmed
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred getting user info", error = ex.Message });
            }
        }
    }

    // DTOs
    public record RegisterRequest(
        string Email,
        string Password,
        string ConfirmPassword,
        string? FirstName = null,
        string? LastName = null,
        string? PhoneNumber = null
    );
}