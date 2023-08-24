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
   public class TempRolePermissionAction : ActionBase  
   {  
       public TempRolePermissionAction()  
       {  
       }  
       public TempRolePermissionAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<TempRolePermissionBusinessModel>> GetAll(  
           Expression<Func<TempRolePermissionBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TempRolePermissionDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<TempRolePermissionBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<TempRolePermissionBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TempRolePermissionDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<TempRolePermissionBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.TempRolePermissionDao.GetAllCount(filter);  
       }  
       public async Task<TempRolePermissionBusinessModel?> Get(Int64 input, string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TempRolePermissionDao.GetByKey(input, includeProperties);  
       }  
       public async Task<TempRolePermissionBusinessModel> Add(TempRolePermissionBusinessModel input)  
       {  
           TempRolePermissionBusinessRule obj = new TempRolePermissionBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.TempRolePermissionDao.Create(input);  
       }  
       public void Modify(TempRolePermissionBusinessModel input)  
       {  
           TempRolePermissionBusinessRule obj = new TempRolePermissionBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TempRolePermissionDao.Update(input);  
       }  
       public void Remove(TempRolePermissionBusinessModel input)  
       {  
           TempRolePermissionBusinessRule obj = new TempRolePermissionBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TempRolePermissionDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.TempRolePermissionDao.Delete(input);  
       }  
       public void Save(TempRolePermissionBusinessModel input)  
       {  
           if (input.TempRolePermissionId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.TempRolePermissionId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
