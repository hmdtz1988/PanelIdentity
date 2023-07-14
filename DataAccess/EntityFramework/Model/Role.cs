using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class Role
{
    public int RoleId { get; set; }

    public int ProjectId { get; set; }

    public long TenantId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreationDate { get; set; }

    public long CreateById { get; set; }

    public DateTime? UpdateDate { get; set; }

    public long? UpdatedById { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteDate { get; set; }

    public long? DeletedById { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<UserInRole> UserInRoles { get; set; } = new List<UserInRole>();
}
