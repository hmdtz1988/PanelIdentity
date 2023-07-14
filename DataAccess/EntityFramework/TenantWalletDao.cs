using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class TenantWalletDao : DaoBaseClass<TenantWallet, TenantWalletBusinessModel>, ITenantWalletDao  
    {  
        public TenantWalletDao(DbContext context) : base(context, "TenantWalletId")  
        {  
        }  
    }  
}  
