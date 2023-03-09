using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace HealthClaimApp.Models
{
    public partial class TblPhysician
    {
        public TblPhysician()
        {
            TblMembers = new HashSet<TblMember>();
        }

        public int PhysicianId { get; set; }
        public string PhysicianName { get; set; }
        public string PhysicianState { get; set; }

        [JsonIgnore]
        public virtual ICollection<TblMember> TblMembers { get; set; }
    }
}
