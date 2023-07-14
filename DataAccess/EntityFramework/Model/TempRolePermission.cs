using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class TempRolePermission
{
    public int TempRolePermissionId { get; set; }

    public int TempRoleId { get; set; }

    public long ServiceActionId { get; set; }

    public DateTime CreationDate { get; set; }

    public long CreateById { get; set; }

    public DateTime? UpdateDate { get; set; }

    public long? UpdatedById { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteDate { get; set; }

    public long? DeletedById { get; set; }

    public virtual ServiceAction ServiceAction { get; set; } = null!;

    public virtual TempRole TempRole { get; set; } = null!;
}
