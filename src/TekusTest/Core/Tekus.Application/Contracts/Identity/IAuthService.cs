using Tekus.Application.Models.Identity;

namespace Tekus.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
    }
}
