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
   public class TenantProjectAction : ActionBase  
   {  
       public TenantProjectAction()  
       {  
       }  
       public TenantProjectAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<TenantProjectBusinessModel>> GetAll(  
           Expression<Func<TenantProjectBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantProjectDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<TenantProjectBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<TenantProjectBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantProjectDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<TenantProjectBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.TenantProjectDao.GetAllCount(filter);  
       }  
       public async Task<TenantProjectBusinessModel?> Get(Int64 input, string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantProjectDao.GetByKey(input, includeProperties);  
       }  
       public async Task<TenantProjectBusinessModel> Add(TenantProjectBusinessModel input)  
       {  
           TenantProjectBusinessRule obj = new TenantProjectBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.TenantProjectDao.Create(input);  
       }  
       public void Modify(TenantProjectBusinessModel input)  
       {  
           TenantProjectBusinessRule obj = new TenantProjectBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TenantProjectDao.Update(input);  
       }  
       public void Remove(TenantProjectBusinessModel input)  
       {  
           TenantProjectBusinessRule obj = new TenantProjectBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TenantProjectDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.TenantProjectDao.Delete(input);  
       }  
       public void Save(TenantProjectBusinessModel input)  
       {  
           if (input.TenantProjectId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.TenantProjectId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
