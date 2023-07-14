using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class UserServiceItemDao : DaoBaseClass<UserServiceItem, UserServiceItemBusinessModel>, IUserServiceItemDao  
    {  
        public UserServiceItemDao(DbContext context) : base(context, "UserServiceItemId")  
        {  
        }  
    }  
}  
