using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class LanguageDao : DaoBaseClass<Language, LanguageBusinessModel>, ILanguageDao  
    {  
        public LanguageDao(DbContext context) : base(context, "LanguageId")  
        {  
        }  
    }  
}  
