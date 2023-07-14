using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class UserPermission
{
    public long UserPermissionId { get; set; }

    public long UserInfoId { get; set; }

    public long TenantId { get; set; }

    public long ServiceActionId { get; set; }

    public bool IsDenied { get; set; }

    public DateTime CreationDate { get; set; }

    public long CreateById { get; set; }

    public DateTime? UpdateDate { get; set; }

    public long? UpdatedById { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteDate { get; set; }

    public long? DeletedById { get; set; }

    public virtual ServiceAction ServiceAction { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual UserInfo UserInfo { get; set; } = null!;
}
