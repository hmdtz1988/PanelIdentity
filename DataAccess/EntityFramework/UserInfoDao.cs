using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class UserInfoDao : DaoBaseClass<UserInfo, UserInfoBusinessModel>, IUserInfoDao  
    {  
        public UserInfoDao(DbContext context) : base(context, "UserInfoId")  
        {  
        }  
    }  
}  
