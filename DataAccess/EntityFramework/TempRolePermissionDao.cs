using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class TempRolePermissionDao : DaoBaseClass<TempRolePermission, TempRolePermissionBusinessModel>, ITempRolePermissionDao  
    {  
        public TempRolePermissionDao(DbContext context) : base(context, "TempRolePermissionId")  
        {  
        }  
    }  
}  
