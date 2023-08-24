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
   public class TempRoleAction : ActionBase  
   {  
       public TempRoleAction()  
       {  
       }  
       public TempRoleAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<TempRoleBusinessModel>> GetAll(  
           Expression<Func<TempRoleBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TempRoleDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<TempRoleBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<TempRoleBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TempRoleDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<TempRoleBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.TempRoleDao.GetAllCount(filter);  
       }  
       public async Task<TempRoleBusinessModel?> Get(Int64 input, string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TempRoleDao.GetByKey(input, includeProperties);  
       }  
       public async Task<TempRoleBusinessModel> Add(TempRoleBusinessModel input)  
       {  
           TempRoleBusinessRule obj = new TempRoleBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.TempRoleDao.Create(input);  
       }  
       public void Modify(TempRoleBusinessModel input)  
       {  
           TempRoleBusinessRule obj = new TempRoleBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TempRoleDao.Update(input);  
       }  
       public void Remove(TempRoleBusinessModel input)  
       {  
           TempRoleBusinessRule obj = new TempRoleBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TempRoleDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.TempRoleDao.Delete(input);  
       }  
       public void Save(TempRoleBusinessModel input)  
       {  
           if (input.TempRoleId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.TempRoleId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
