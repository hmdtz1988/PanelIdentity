using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class ServiceActionDao : DaoBaseClass<ServiceAction, ServiceActionBusinessModel>, IServiceActionDao  
    {  
        public ServiceActionDao(DbContext context) : base(context, "ServiceActionId")  
        {  
        }  
    }  
}  
