using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class RolePermissionDao : DaoBaseClass<RolePermission, RolePermissionBusinessModel>, IRolePermissionDao  
    {  
        public RolePermissionDao(DbContext context) : base(context, "RolePermissionId")  
        {  
        }  
    }  
}  
