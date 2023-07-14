using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class UserDevice
{
    public int UserDeviceId { get; set; }

    public long? UserInfoId { get; set; }

    public string? DeviceKey { get; set; }

    public string? DeviceLocalKey { get; set; }

    public string? DeviceName { get; set; }

    public string? AppStoreId { get; set; }

    public string? DeviceType { get; set; }

    public string? Version { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual UserInfo? UserInfo { get; set; }
}
