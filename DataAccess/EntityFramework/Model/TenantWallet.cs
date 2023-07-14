using System;
using System.Collections.Generic;

namespace DataAccess.EntityFramework.Model;

public partial class TenantWallet
{
    public long TenantWalletId { get; set; }

    public long TenantId { get; set; }

    public int CurrencyId { get; set; }

    public string WalletNo { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<TenantWalletTransaction> TenantWalletTransactions { get; set; } = new List<TenantWalletTransaction>();
}
