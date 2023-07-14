using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class Language
{
    public int LanguageId { get; set; }

    public string Title { get; set; } = null!;

    public string? Code { get; set; }

    public string? Logo { get; set; }

    public int CurrencyId { get; set; }
}
