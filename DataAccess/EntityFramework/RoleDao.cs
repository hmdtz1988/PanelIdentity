using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class RoleDao : DaoBaseClass<Role, RoleBusinessModel>, IRoleDao  
    {  
        public RoleDao(DbContext context) : base(context, "RoleId")  
        {  
        }  
    }  
}  
