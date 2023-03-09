using System;
using System.Collections.Generic;

#nullable disable

namespace HealthClaimApp.Models
{
    public partial class TblClaimType
    {
        public TblClaimType()
        {
            TblClaims = new HashSet<TblClaim>();
        }

        public int ClaimTypeId { get; set; }
        public string ClaimTypeValue { get; set; }

        public virtual ICollection<TblClaim> TblClaims { get; set; }
    }
}
