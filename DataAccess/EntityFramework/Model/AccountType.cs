using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class AccountType
{
    public int AccountTypeId { get; set; }

    public string TitleFa { get; set; } = null!;

    public string? TitleEn { get; set; }

    public string? TitleTr { get; set; }

    public string? TitleAr { get; set; }

    public string? TitleDu { get; set; }

    public string? TitleFr { get; set; }

    public virtual ICollection<ProjectAccountType> ProjectAccountTypes { get; set; } = new List<ProjectAccountType>();
}
