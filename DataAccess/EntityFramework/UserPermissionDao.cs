using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class UserPermissionDao : DaoBaseClass<UserPermission, UserPermissionBusinessModel>, IUserPermissionDao  
    {  
        public UserPermissionDao(DbContext context) : base(context, "UserPermissionId")  
        {  
        }  
    }  
}  
