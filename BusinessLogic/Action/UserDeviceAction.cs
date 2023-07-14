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
   public class UserDeviceAction : ActionBase  
   {  
       public UserDeviceAction()  
       {  
       }  
       public UserDeviceAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<UserDeviceBusinessModel>> GetAll(  
           Expression<Func<UserDeviceBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.UserDeviceDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<UserDeviceBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<UserDeviceBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.UserDeviceDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<UserDeviceBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.UserDeviceDao.GetAllCount(filter);  
       }  
       public async Task<UserDeviceBusinessModel?> Get(Int64 input, string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.UserDeviceDao.GetByKey(input, includeProperties);  
       }  
       public void Add(UserDeviceBusinessModel input)  
       {  
           UserDeviceBusinessRule obj = new UserDeviceBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.UserDeviceDao.Create(input);  
       }  
       public void Modify(UserDeviceBusinessModel input)  
       {  
           UserDeviceBusinessRule obj = new UserDeviceBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.UserDeviceDao.Update(input);  
       }  
       public void Remove(UserDeviceBusinessModel input)  
       {  
           UserDeviceBusinessRule obj = new UserDeviceBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.UserDeviceDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.UserDeviceDao.Delete(input);  
       }  
       public void Save(UserDeviceBusinessModel input)  
       {  
           if (input.UserDeviceId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.UserDeviceId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
