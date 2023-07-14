using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class Project
{
    public int ProjectId { get; set; }

    public string TitleFa { get; set; } = null!;

    public string? TitleEn { get; set; }

    public string? TitleTr { get; set; }

    public string? TitleAr { get; set; }

    public string? TitleDu { get; set; }

    public string? TitleFr { get; set; }

    public string? Url { get; set; }

    public string? Icon { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();

    public virtual ICollection<ProjectAccountType> ProjectAccountTypes { get; set; } = new List<ProjectAccountType>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
