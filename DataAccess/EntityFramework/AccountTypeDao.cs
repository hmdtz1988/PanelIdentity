using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class AccountTypeDao : DaoBaseClass<AccountType, AccountTypeBusinessModel>, IAccountTypeDao  
    {  
        public AccountTypeDao(DbContext context) : base(context, "AccountTypeId")  
        {  
        }  
    }  
}  
