using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;
using Core.Extensions;
using StackExchange.Redis;
using System.Linq.Expressions;

namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class TenantWalletTransactionDao : DaoBaseClass<TenantWalletTransaction, TenantWalletTransactionBusinessModel>, ITenantWalletTransactionDao  
    {  
        public TenantWalletTransactionDao(DbContext context) : base(context, "TenantWalletTransactionId")  
        {
        }

        public Task<decimal> GetWalletRemaining(long TenantId)
        {
            IQueryable<TenantWalletTransaction> query = _repository.Get(x=> x.TenantId == TenantId);
            return query.SumAsync(x=> x.Credit - x.Debit);

        }
    }  
}  
