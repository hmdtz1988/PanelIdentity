using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class TenantWalletTransactionDao : DaoBaseClass<TenantWalletTransaction, TenantWalletTransactionBusinessModel>, ITenantWalletTransactionDao  
    {  
        public TenantWalletTransactionDao(DbContext context) : base(context, "TenantWalletTransactionId")  
        {  
        }  
    }  
}  
