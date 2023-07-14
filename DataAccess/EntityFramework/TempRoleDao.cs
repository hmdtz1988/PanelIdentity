using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class TempRoleDao : DaoBaseClass<TempRole, TempRoleBusinessModel>, ITempRoleDao  
    {  
        public TempRoleDao(DbContext context) : base(context, "TempRoleId")  
        {  
        }  
    }  
}  
