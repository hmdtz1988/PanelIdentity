using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class UserInfo
{
    public long UserInfoId { get; set; }

    public string? NationalCode { get; set; }

    public string? UserName { get; set; }

    public string? PhoneCode { get; set; }

    public string MobileNo { get; set; } = null!;

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; } = null!;

    public string? Avatar { get; set; }

    public byte Status { get; set; }

    public string? ActivationCode { get; set; }

    public long? RealPersonId { get; set; }

    public bool IsFullAdmin { get; set; }

    public bool IsActive { get; set; }

    public bool IsLock { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public TimeSpan? FromTime { get; set; }

    public TimeSpan? ToTime { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();

    public virtual ICollection<QRLoginTransaction> QRLoginTransactions { get; set; } = new List<QRLoginTransaction>();

    public virtual ICollection<UserDevice> UserDevices { get; set; } = new List<UserDevice>();

    public virtual ICollection<UserInRole> UserInRoles { get; set; } = new List<UserInRole>();

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    public virtual ICollection<UserServiceItem> UserServiceItems { get; set; } = new List<UserServiceItem>();

    public virtual ICollection<UserTenant> UserTenants { get; set; } = new List<UserTenant>();
}
