using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class Currency
{
    public int CurrencyId { get; set; }

    public string Title { get; set; } = null!;

    public string? Symbol { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();

    public virtual ICollection<ProjectAccountType> ProjectAccountTypes { get; set; } = new List<ProjectAccountType>();

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
