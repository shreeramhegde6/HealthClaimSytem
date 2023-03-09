using HealthClaimApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClaimApp.Services
{
   public interface IClaimService
    {
        IEnumerable<TblClaimType> GetAllClaimType();
        TblClaim SaveClaim(TblClaim claim);
    }
}
