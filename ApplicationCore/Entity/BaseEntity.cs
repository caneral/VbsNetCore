using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entity
{
    /// <summary>
    /// Core Base Entity Class
    /// </summary>
    public class BaseEntity : ISoftDeleted
    {
        public BaseEntity()
        {
            IsDeleted = false;
            Status = StatusType.Active;
        }

        public StatusType Status { get; set; }

        public bool IsDeleted { get; set; }
    }
}
