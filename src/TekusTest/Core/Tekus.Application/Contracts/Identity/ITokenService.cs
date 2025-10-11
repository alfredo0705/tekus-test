using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekus.Application.Models.Identity;

namespace Tekus.Application.Contracts.Identity
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUserDto user);
    }
}
