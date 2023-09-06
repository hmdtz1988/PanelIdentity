using BusinessModel;   
using System.Linq.Expressions;  
namespace DataAccess.Interfaces  
{  
    public interface ITenantWalletTransactionDao : IBaseInterfaceDao<TenantWalletTransactionBusinessModel>  
    {
        Task<decimal> GetWalletRemaining(long TenantId);

    }
}  
