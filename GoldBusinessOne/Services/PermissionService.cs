using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace GoldBusinessOne.Services
{
    public interface IPermissionService
    {
        bool HasPermission(string area, string level);
        bool HasAnyPermission(params string[] areaLevelPairs);
        bool HasRole(string role);
        bool HasAnyRole(params string[] roles);
        string[] GetPermissions();
        string[] GetRoles();
        string GetUserId();
        string GetUserName();
    }

    public class PermissionService : IPermissionService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public PermissionService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task InitializeAsync()
        {
            // Inicializar si es necesario
            await Task.CompletedTask;
        }

        public async Task<bool> HasPermissionAsync(string area, string level)
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            // Verificar claim específico
            var claim = user.FindFirst($"perm.{area}");
            if (claim != null)
            {
                var levels = claim.Value.Split(',');
                return levels.Contains(level) || levels.Contains("full");
            }

            // Verificar en el claim consolidado de permisos
            var permissionsClaim = user.FindFirst("permissions");
            if (permissionsClaim != null)
            {
                var permissions = permissionsClaim.Value.Split(',')
                    .Select(p => p.Split(':'))
                    .Where(parts => parts.Length == 2)
                    .ToDictionary(parts => parts[0], parts => parts[1]);

                if (permissions.ContainsKey(area))
                {
                    var areaLevels = permissions[area].Split(',');
                    return areaLevels.Contains(level) || areaLevels.Contains("full");
                }
            }

            return false;
        }

        public bool HasPermission(string area, string level)
        {
            return HasPermissionAsync(area, level).GetAwaiter().GetResult();
        }

        public async Task<bool> HasAnyPermissionAsync(params string[] areaLevelPairs)
        {
            foreach (var pair in areaLevelPairs)
            {
                var parts = pair.Split(':');
                if (parts.Length == 2 && await HasPermissionAsync(parts[0], parts[1]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasAnyPermission(params string[] areaLevelPairs)
        {
            return HasAnyPermissionAsync(areaLevelPairs).GetAwaiter().GetResult();
        }

        public async Task<bool> HasRoleAsync(string role)
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            return authState.User.IsInRole(role);
        }

        public bool HasRole(string role)
        {
            return HasRoleAsync(role).GetAwaiter().GetResult();
        }

        public async Task<bool> HasAnyRoleAsync(params string[] roles)
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            foreach (var role in roles)
            {
                if (user.IsInRole(role))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasAnyRole(params string[] roles)
        {
            return HasAnyRoleAsync(roles).GetAwaiter().GetResult();
        }

        public async Task<string[]> GetPermissionsAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            var permissionsClaim = user.FindFirst("permissions");
            if (permissionsClaim != null)
            {
                return permissionsClaim.Value.Split(',');
            }

            return Array.Empty<string>();
        }

        public string[] GetPermissions()
        {
            return GetPermissionsAsync().GetAwaiter().GetResult();
        }

        public async Task<string[]> GetRolesAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            return user.Claims
                .Where(c => c.Type == ClaimTypes.Role || c.Type == "role")
                .Select(c => c.Value)
                .Distinct()
                .ToArray();
        }

        public string[] GetRoles()
        {
            return GetRolesAsync().GetAwaiter().GetResult();
        }

        public async Task<string> GetUserIdAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            return authState.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        public string GetUserId()
        {
            return GetUserIdAsync().GetAwaiter().GetResult();
        }

        public async Task<string> GetUserNameAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            return authState.User.Identity?.Name ?? string.Empty;
        }

        public string GetUserName()
        {
            return GetUserNameAsync().GetAwaiter().GetResult();
        }
    }
}