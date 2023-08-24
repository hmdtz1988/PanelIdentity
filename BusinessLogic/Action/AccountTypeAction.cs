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
   public class AccountTypeAction : ActionBase  
   {  
       public AccountTypeAction()  
       {  
       }  
       public AccountTypeAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<AccountTypeBusinessModel>> GetAll(  
           Expression<Func<AccountTypeBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.AccountTypeDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<AccountTypeBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<AccountTypeBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.AccountTypeDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<AccountTypeBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.AccountTypeDao.GetAllCount(filter);  
       }  
       public async Task<AccountTypeBusinessModel?> Get(Int64 input, string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.AccountTypeDao.GetByKey(input, includeProperties);  
       }  
       public async Task<AccountTypeBusinessModel> Add(AccountTypeBusinessModel input)  
       {  
           AccountTypeBusinessRule obj = new AccountTypeBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());
            return await FactoryContainer.Factory.AccountTypeDao.Create(input);  
       }  
       public void Modify(AccountTypeBusinessModel input)  
       {  
           AccountTypeBusinessRule obj = new AccountTypeBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.AccountTypeDao.Update(input);  
       }  
       public void Remove(AccountTypeBusinessModel input)  
       {  
           AccountTypeBusinessRule obj = new AccountTypeBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.AccountTypeDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.AccountTypeDao.Delete(input);  
       }  
       public void Save(AccountTypeBusinessModel input)  
       {  
           if (input.AccountTypeId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.AccountTypeId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
