using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class ServiceItem
{
    public long ServiceItemId { get; set; }

    public int ServiceId { get; set; }

    public long TenantId { get; set; }

    public string PropertyName1 { get; set; } = null!;

    public long PropertyValue1 { get; set; }

    public string? PropertyName2 { get; set; }

    public string? PropertyValue2 { get; set; }

    public DateTime CreationDate { get; set; }

    public long CreateById { get; set; }

    public DateTime? UpdateDate { get; set; }

    public long? UpdatedById { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteDate { get; set; }

    public long? DeletedById { get; set; }

    public virtual Service Service { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<UserServiceItem> UserServiceItems { get; set; } = new List<UserServiceItem>();
}
