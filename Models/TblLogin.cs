using System;
using System.Collections.Generic;

#nullable disable

namespace HealthClaimApp.Models
{
    public partial class TblLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
