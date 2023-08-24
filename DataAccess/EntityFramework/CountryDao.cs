using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class CountryDao : DaoBaseClass<Country, CountryBusinessModel>, ICountryDao  
    {  
        public CountryDao(DbContext context) : base(context, "CountryId")  
        {  
        }  
    }  
}  
