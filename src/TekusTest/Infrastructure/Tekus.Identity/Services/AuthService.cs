using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Tekus.Application.Contracts.Identity;
using Tekus.Application.Exceptions;
using Tekus.Application.Models.Identity;
using Tekus.Identity.Entities;

namespace Tekus.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IOptions<JwtSettings> jwtSettings,
            ITokenService tokenService,
            RoleManager<AppRole> roleManager,
            IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings.Value));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _roleManager = roleManager;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == request.Username.ToLower());

            if (user == null)
                throw new NotFoundException("Usuario no encontrado.", request.Username);

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded) throw new BadRequestException($"Credenciales para '{request.Username} no son validas'.");

            if (result.IsLockedOut) throw new BadRequestException($"Usuario '{request.Username} bloqueado'.");

            var roles = await _userManager.GetRolesAsync(user);

            AuthResponse response = new AuthResponse();

            var userDto = new AppUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };

            if (roles == null || roles.Count == 0) throw new BadRequestException($"Usuario '{request.Username} no tiene roles asignados'.");

            response = new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                Role = roles.ToList(),
                Username = user.UserName,
                Token = await _tokenService.CreateToken(userDto)
            };

            return response;
        }
    }
}
