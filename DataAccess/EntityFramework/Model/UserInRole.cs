﻿using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class UserInRole
{
    public long UserInRoleId { get; set; }

    public int RoleId { get; set; }

    public long UserInfoId { get; set; }

    public long TenantId { get; set; }

    public DateTime CreationDate { get; set; }

    public long CreateById { get; set; }

    public DateTime? UpdateDate { get; set; }

    public long? UpdatedById { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteDate { get; set; }

    public long? DeletedById { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual UserInfo UserInfo { get; set; } = null!;
}
