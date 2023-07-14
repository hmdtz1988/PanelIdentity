using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class ServiceAction
{
    public long ServiceActionId { get; set; }

    public int ServiceId { get; set; }

    public string? TitleFa { get; set; }

    public string? TitleEn { get; set; }

    public string? TitleAr { get; set; }

    public string? TitleTr { get; set; }

    public string? TitleDu { get; set; }

    public string? TitleFr { get; set; }

    public string? ApiController { get; set; }

    public string? ApiService { get; set; }

    public bool NeedAuth { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual Service Service { get; set; } = null!;

    public virtual ICollection<TempRolePermission> TempRolePermissions { get; set; } = new List<TempRolePermission>();

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}
