using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class ProjectAccountTypeDao : DaoBaseClass<ProjectAccountType, ProjectAccountTypeBusinessModel>, IProjectAccountTypeDao  
    {  
        public ProjectAccountTypeDao(DbContext context) : base(context, "ProjectAccountTypeId")  
        {  
        }  
    }  
}  
