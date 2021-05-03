using System;

namespace ApplicationCore.Entity.Identity
{
    public class AppUserClaim : BaseEntity, IAudit
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUserFK { get; set; }
        public int AppClaimId { get; set; }
        public AppClaim AppClaimFK { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
