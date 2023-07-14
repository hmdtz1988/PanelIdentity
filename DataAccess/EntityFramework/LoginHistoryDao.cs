using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class LoginHistoryDao : DaoBaseClass<LoginHistory, LoginHistoryBusinessModel>, ILoginHistoryDao  
    {  
        public LoginHistoryDao(DbContext context) : base(context, "LoginHistoryId")  
        {  
        }  
    }  
}  
