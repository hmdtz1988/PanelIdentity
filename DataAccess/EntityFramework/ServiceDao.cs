using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class ServiceDao : DaoBaseClass<Service, ServiceBusinessModel>, IServiceDao  
    {  
        public ServiceDao(DbContext context) : base(context, "ServiceId")  
        {  
        }  
    }  
}  
