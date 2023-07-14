using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class ServiceItemDao : DaoBaseClass<ServiceItem, ServiceItemBusinessModel>, IServiceItemDao  
    {  
        public ServiceItemDao(DbContext context) : base(context, "ServiceItemId")  
        {  
        }  
    }  
}  
