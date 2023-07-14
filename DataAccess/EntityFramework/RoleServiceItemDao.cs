using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class RoleServiceItemDao : DaoBaseClass<RoleServiceItem, RoleServiceItemBusinessModel>, IRoleServiceItemDao  
    {  
        public RoleServiceItemDao(DbContext context) : base(context, "RoleServiceItemId")  
        {  
        }  
    }  
}  
