using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class TenantDao : DaoBaseClass<Tenant, TenantBusinessModel>, ITenantDao  
    {  
        public TenantDao(DbContext context) : base(context, "TenantId")  
        {  
        }  
    }  
}  
