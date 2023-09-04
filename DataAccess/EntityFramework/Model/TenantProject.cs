using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class TenantProject
{
    public long TenantProjectId { get; set; }

    public long TenantId { get; set; }

    public int ProjectId { get; set; }

    public DateTime StartDate { get; set; }

    public int AccountTypeId { get; set; }

    public bool IsActice { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;
}
