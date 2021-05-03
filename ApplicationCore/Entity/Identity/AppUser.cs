using System;
using System.Collections.Generic;

namespace ApplicationCore.Entity.Identity
{
    public class AppUser : BaseEntity, IAudit
    {
        public AppUser()
        {
            AppUserClaims = new List<AppUserClaim>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public ICollection<AppUserClaim> AppUserClaims { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int UserRole { get; set; }
    }
}
