using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class UserTenant
{
    public long UserTenantId { get; set; }

    public long TenantId { get; set; }

    public long UserId { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual UserInfo User { get; set; } = null!;
}
