using Tekus.Application.Models.Identity;

namespace Tekus.Application.Contracts.Identity
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUserDto user);
    }
}
