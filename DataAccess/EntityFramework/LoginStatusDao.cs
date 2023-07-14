using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class LoginStatusDao : DaoBaseClass<LoginStatus, LoginStatusBusinessModel>, ILoginStatusDao  
    {  
        public LoginStatusDao(DbContext context) : base(context, "LoginStatusId")  
        {  
        }  
    }  
}  
