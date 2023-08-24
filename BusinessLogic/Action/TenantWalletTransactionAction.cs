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
   public class TenantWalletTransactionAction : ActionBase  
   {  
       public TenantWalletTransactionAction()  
       {  
       }  
       public TenantWalletTransactionAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<TenantWalletTransactionBusinessModel>> GetAll(  
           Expression<Func<TenantWalletTransactionBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantWalletTransactionDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<TenantWalletTransactionBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<TenantWalletTransactionBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantWalletTransactionDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<TenantWalletTransactionBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.TenantWalletTransactionDao.GetAllCount(filter);  
       }  
       public async Task<TenantWalletTransactionBusinessModel?> Get(Int64 input, string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantWalletTransactionDao.GetByKey(input, includeProperties);  
       }  
       public async Task<TenantWalletTransactionBusinessModel> Add(TenantWalletTransactionBusinessModel input)  
       {  
           TenantWalletTransactionBusinessRule obj = new TenantWalletTransactionBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.TenantWalletTransactionDao.Create(input);  
       }  
       public void Modify(TenantWalletTransactionBusinessModel input)  
       {  
           TenantWalletTransactionBusinessRule obj = new TenantWalletTransactionBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TenantWalletTransactionDao.Update(input);  
       }  
       public void Remove(TenantWalletTransactionBusinessModel input)  
       {  
           TenantWalletTransactionBusinessRule obj = new TenantWalletTransactionBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TenantWalletTransactionDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.TenantWalletTransactionDao.Delete(input);  
       }  
       public void Save(TenantWalletTransactionBusinessModel input)  
       {  
           if (input.TenantWalletTransactionId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.TenantWalletTransactionId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
