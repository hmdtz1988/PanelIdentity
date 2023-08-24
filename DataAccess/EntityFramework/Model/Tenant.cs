using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class Tenant
{
    public long TenantId { get; set; }

    public string? Title { get; set; }

    public long? ParentId { get; set; }

    public int? CountryId { get; set; }

    public int? LanguageId { get; set; }

    public int? CurrencyId { get; set; }

    public int? WalletNumber { get; set; }

    public string? InviteKey { get; set; }

    public bool IsDemo { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public bool HasDebit { get; set; }

    public bool IsMain { get; set; }

    public DateTime? ExpireDate { get; set; }

    public long? CompanyId { get; set; }

    public string? Logo { get; set; }

    public DateTime CreationDate { get; set; }

    public long CreateById { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteDate { get; set; }

    public long? DeletedById { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Tenant> InverseParent { get; set; } = new List<Tenant>();

    public virtual Language? Language { get; set; }

    public virtual ICollection<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();

    public virtual Tenant? Parent { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<ServiceItem> ServiceItems { get; set; } = new List<ServiceItem>();

    public virtual ICollection<TenantWalletTransaction> TenantWalletTransactions { get; set; } = new List<TenantWalletTransaction>();

    public virtual ICollection<UserInRole> UserInRoles { get; set; } = new List<UserInRole>();

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    public virtual ICollection<UserTenant> UserTenants { get; set; } = new List<UserTenant>();
}
