using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class QRLoginTransaction
{
    public long QRLoginTransactionId { get; set; }

    public string? TransactionToken { get; set; }

    public long? UserInfoId { get; set; }

    public string? DeviceKey { get; set; }

    public string? DeviceLocalKey { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ExpireDate { get; set; }

    public bool IsConfirmed { get; set; }

    public virtual UserInfo? UserInfo { get; set; }
}
