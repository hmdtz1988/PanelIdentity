using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class Service
{
    public int ServiceId { get; set; }

    public int? ParentId { get; set; }

    public int? ProjectId { get; set; }

    public string TitleFa { get; set; } = null!;

    public string? TitleEn { get; set; }

    public string? TitleTr { get; set; }

    public string? TitleAr { get; set; }

    public string? TitleDu { get; set; }

    public string? TitleFr { get; set; }

    public string? Controller { get; set; }

    public string? Icon { get; set; }

    public bool IsService { get; set; }

    public int ItemOrder { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<Service> InverseParent { get; set; } = new List<Service>();

    public virtual Service? Parent { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<ServiceAction> ServiceActions { get; set; } = new List<ServiceAction>();

    public virtual ICollection<ServiceItem> ServiceItems { get; set; } = new List<ServiceItem>();
}
