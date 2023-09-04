using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class TenantProjectDao : DaoBaseClass<TenantProject, TenantProjectBusinessModel>, ITenantProjectDao  
    {  
        public TenantProjectDao(DbContext context) : base(context, "TenantProjectId")  
        {  
        }  
    }  
}  
