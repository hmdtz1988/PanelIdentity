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
   public class ProjectAction : ActionBase  
   {  
       public ProjectAction()  
       {  
       }  
       public ProjectAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<ProjectBusinessModel>> GetAll(  
           Expression<Func<ProjectBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.ProjectDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<ProjectBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<ProjectBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.ProjectDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<ProjectBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.ProjectDao.GetAllCount(filter);  
       }  
       public async Task<ProjectBusinessModel?> Get(Int64 input, string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.ProjectDao.GetByKey(input, includeProperties);  
       }  
       public async Task<ProjectBusinessModel> Add(ProjectBusinessModel input)  
       {  
           ProjectBusinessRule obj = new ProjectBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.ProjectDao.Create(input);  
       }  
       public void Modify(ProjectBusinessModel input)  
       {  
           ProjectBusinessRule obj = new ProjectBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.ProjectDao.Update(input);  
       }  
       public void Remove(ProjectBusinessModel input)  
       {  
           ProjectBusinessRule obj = new ProjectBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.ProjectDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.ProjectDao.Delete(input);  
       }  
       public void Save(ProjectBusinessModel input)  
       {  
           if (input.ProjectId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.ProjectId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
