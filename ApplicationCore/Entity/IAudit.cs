using System;

namespace ApplicationCore.Entity
{
    /// <summary>
    /// Core Audit Entities 
    /// </summary>
    public interface IAudit
    {
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; } 
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
