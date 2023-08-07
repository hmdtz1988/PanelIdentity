using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class UserTenantBusinessModel : BusinessModelBase
    {
        public long? UserTenantId { get; set; }

        public long TenantId { get; set; }

        public long UserId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual TenantBusinessModel Tenant { get; set; } = null!;
    }
}
