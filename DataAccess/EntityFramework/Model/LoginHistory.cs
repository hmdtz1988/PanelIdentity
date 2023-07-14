using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class LoginHistory
{
    public long LoginHistoryId { get; set; }

    public long UserInfoId { get; set; }

    public long TenantId { get; set; }

    public int ProjectId { get; set; }

    public int LoginStatusId { get; set; }

    public string? UserHostAddress { get; set; }

    public string Token { get; set; } = null!;

    public string? Version { get; set; }

    public string? Chanel { get; set; }

    public DateTime? LoginDateTime { get; set; }

    public DateTime? LogoutDateTime { get; set; }

    public DateTime? ExpireDateTime { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual LoginStatus LoginStatus { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual UserInfo UserInfo { get; set; } = null!;
}
