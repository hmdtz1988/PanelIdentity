using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class TempRole
{
    public int TempRoleId { get; set; }

    public int ProjectId { get; set; }

    public string? TitleFa { get; set; }

    public string? TitleAr { get; set; }

    public string? TitleEn { get; set; }

    public string? TitleTr { get; set; }

    public string? TitleDu { get; set; }

    public string? TitleFr { get; set; }

    public string? Description { get; set; }

    public DateTime CreationDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteDate { get; set; }

    public virtual ICollection<TempRolePermission> TempRolePermissions { get; set; } = new List<TempRolePermission>();
}
