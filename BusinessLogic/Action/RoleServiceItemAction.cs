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
   public class RoleServiceItemAction : ActionBase  
   {  
       public RoleServiceItemAction()  
       {  
       }  
       public RoleServiceItemAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<RoleServiceItemBusinessModel>> GetAll(  
           Expression<Func<RoleServiceItemBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.RoleServiceItemDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<RoleServiceItemBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<RoleServiceItemBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.RoleServiceItemDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<RoleServiceItemBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.RoleServiceItemDao.GetAllCount(filter);  
       }  
       public async Task<RoleServiceItemBusinessModel?> Get(Int64 input, string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.RoleServiceItemDao.GetByKey(input, includeProperties);  
       }  
       public async Task<RoleServiceItemBusinessModel> Add(RoleServiceItemBusinessModel input)  
       {  
           RoleServiceItemBusinessRule obj = new RoleServiceItemBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.RoleServiceItemDao.Create(input);  
       }  
       public void Modify(RoleServiceItemBusinessModel input)  
       {  
           RoleServiceItemBusinessRule obj = new RoleServiceItemBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.RoleServiceItemDao.Update(input);  
       }  
       public void Remove(RoleServiceItemBusinessModel input)  
       {  
           RoleServiceItemBusinessRule obj = new RoleServiceItemBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.RoleServiceItemDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.RoleServiceItemDao.Delete(input);  
       }  
       public void Save(RoleServiceItemBusinessModel input)  
       {  
           if (input.RoleServiceItemId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.RoleServiceItemId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
