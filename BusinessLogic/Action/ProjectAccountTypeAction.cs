using BusinessLogic.BusinessModelRules;  
using BusinessModel;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Linq.Expressions;  
using System.Text;  
using System.Threading.Tasks;  
namespace BusinessLogic.Action  
{  
   public class ProjectAccountTypeAction : ActionBase  
   {  
       public ProjectAccountTypeAction()  
       {  
       }  
       public ProjectAccountTypeAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<ProjectAccountTypeBusinessModel>> GetAll(  
           Expression<Func<ProjectAccountTypeBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.ProjectAccountTypeDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<ProjectAccountTypeBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<ProjectAccountTypeBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.ProjectAccountTypeDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<ProjectAccountTypeBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.ProjectAccountTypeDao.GetAllCount(filter);  
       }  
       public async Task<ProjectAccountTypeBusinessModel?> Get(Int64 input, string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.ProjectAccountTypeDao.GetByKey(input, includeProperties);  
       }  
       public async Task<ProjectAccountTypeBusinessModel> Add(ProjectAccountTypeBusinessModel input)  
       {  
           ProjectAccountTypeBusinessRule obj = new ProjectAccountTypeBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.ProjectAccountTypeDao.Create(input);  
       }  
       public void Modify(ProjectAccountTypeBusinessModel input)  
       {  
           ProjectAccountTypeBusinessRule obj = new ProjectAccountTypeBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.ProjectAccountTypeDao.Update(input);  
       }  
       public void Remove(ProjectAccountTypeBusinessModel input)  
       {  
           ProjectAccountTypeBusinessRule obj = new ProjectAccountTypeBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.ProjectAccountTypeDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.ProjectAccountTypeDao.Delete(input);  
       }  
       public void Save(ProjectAccountTypeBusinessModel input)  
       {  
           if (input.ProjectAccountTypeId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.ProjectAccountTypeId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
