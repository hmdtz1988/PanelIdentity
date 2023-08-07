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
   public class TenentProjectAction : ActionBase  
   {  
       public TenentProjectAction()  
       {  
       }  
       public TenentProjectAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<TenantProjectBusinessModel>> GetAll(  
           Expression<Func<TenantProjectBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenentProjectDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<TenantProjectBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<TenantProjectBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenentProjectDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<TenantProjectBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.TenentProjectDao.GetAllCount(filter);  
       }  
       public async Task<TenantProjectBusinessModel?> Get(Int64 input, string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenentProjectDao.GetByKey(input, includeProperties);  
       }  
       public async Task<TenantProjectBusinessModel> Add(TenantProjectBusinessModel input)  
       {  
           TenentProjectBusinessRule obj = new TenentProjectBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.TenentProjectDao.Create(input);  
       }  
       public void Modify(TenantProjectBusinessModel input)  
       {  
           TenentProjectBusinessRule obj = new TenentProjectBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TenentProjectDao.Update(input);  
       }  
       public void Remove(TenantProjectBusinessModel input)  
       {  
           TenentProjectBusinessRule obj = new TenentProjectBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TenentProjectDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.TenentProjectDao.Delete(input);  
       }  
       public void Save(TenantProjectBusinessModel input)  
       {  
           if (input.TenentProjectId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.TenentProjectId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
