using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class CurrencyDao : DaoBaseClass<Currency, CurrencyBusinessModel>, ICurrencyDao  
    {  
        public CurrencyDao(DbContext context) : base(context, "CurrencyId")  
        {  
        }  
    }  
}  
