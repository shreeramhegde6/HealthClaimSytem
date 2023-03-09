using HealthClaimApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthClaimApp.Services
{
    public class ClaimService : IClaimService
    {

        HealthclaimAppContext db;
        public ClaimService(HealthclaimAppContext _db)
        {
            db = _db;
        }

        public IEnumerable<TblClaimType> GetAllClaimType()
        {
            var claimTypeList = db.TblClaimTypes.ToList();
            return claimTypeList;
        }
        public TblClaim SaveClaim(TblClaim claim)
        {
            try
            {
                claim.MemberId = Convert.ToInt32(claim.MemberId);
                claim.CreatedBy = "admin";
                claim.CreatedDate = DateTime.Now;
                claim.ModifiedBy = "admin";
                claim.ModifiedDate = DateTime.Now;
                db.TblClaims.Add(claim);
                db.SaveChanges();
                return claim;
            }
            catch (Exception ex)
            {
                return claim;
            }
        }
    }
}
