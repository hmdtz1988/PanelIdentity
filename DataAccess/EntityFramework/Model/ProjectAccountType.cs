using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class ProjectAccountType
{
    public long ProjectAccountTypeId { get; set; }

    public int ProjectId { get; set; }

    public int AccountTypeId { get; set; }

    public byte PeriodType { get; set; }

    public int CurrencyId { get; set; }

    public decimal Amount { get; set; }

    public virtual AccountType AccountType { get; set; } = null!;

    public virtual Currency Currency { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
