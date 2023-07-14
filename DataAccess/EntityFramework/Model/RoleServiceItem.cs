using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class RoleServiceItem
{
    public long RoleServiceItemId { get; set; }

    public long RoleId { get; set; }

    public long ServiceItemId { get; set; }

    public DateTime CreationDate { get; set; }

    public long CreateById { get; set; }

    public DateTime? UpdateDate { get; set; }

    public long? UpdatedById { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeleteDate { get; set; }

    public long? DeletedById { get; set; }
}
