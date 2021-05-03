using System;
using System.Collections.Generic;

namespace ApplicationCore.Entity.Identity
{
    public class AppClaim : BaseEntity, IAudit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AppUserClaim> AppUserClaims { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
