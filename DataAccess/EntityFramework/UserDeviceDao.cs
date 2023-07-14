using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class UserDeviceDao : DaoBaseClass<UserDevice, UserDeviceBusinessModel>, IUserDeviceDao  
    {  
        public UserDeviceDao(DbContext context) : base(context, "UserDeviceId")  
        {  
        }  
    }  
}  
