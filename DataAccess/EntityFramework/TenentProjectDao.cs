using Microsoft.EntityFrameworkCore;   
using BusinessModel;  
using DataAccess.Interfaces;  
using DataAccess.EntityFramework.Model;  
namespace DataAccess.EntityFramework.MS_SQL  
{  
    public class TenentProjectDao : DaoBaseClass<TenentProject, TenantProjectBusinessModel>, ITenentProjectDao  
    {  
        public TenentProjectDao(DbContext context) : base(context, "TenentProjectId")  
        {  
        }  
    }  
}  
