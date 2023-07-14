using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class ProjectDao : DaoBaseClass<Project, ProjectBusinessModel>, IProjectDao  
    {  
        public ProjectDao(DbContext context) : base(context, "ProjectId")  
        {  
        }  
    }  
}  
