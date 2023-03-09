using HealthClaimApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClaimApp.Services
{
    public interface ILoginService
    {
        Task<string> Login(TblLogin login, bool Isregister);
        Task<string> Register(TblLogin user, bool Isregister);
        TblLogin AuthenticateUser(TblLogin login, bool IsRegister);
        string GenerateToken(TblLogin login);
    }
}
