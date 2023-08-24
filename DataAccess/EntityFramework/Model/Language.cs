using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class Language
{
    public int LanguageId { get; set; }

    public string Title { get; set; } = null!;

    public string? Code { get; set; }

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
