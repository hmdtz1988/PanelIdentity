using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class Country
{
    public int CountryId { get; set; }

    public string Title { get; set; } = null!;

    public int LanguageId { get; set; }

    public int CurrencyId { get; set; }

    public string? PhoneCode { get; set; }

    public string? FlagUrl { get; set; }

    public string? CountryCode { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual Language Language { get; set; } = null!;

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
