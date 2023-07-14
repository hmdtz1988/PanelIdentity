using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class UserInRoleDao : DaoBaseClass<UserInRole, UserInRoleBusinessModel>, IUserInRoleDao  
    {  
        public UserInRoleDao(DbContext context) : base(context, "UserInRoleId")  
        {  
        }  
    }  
}  
