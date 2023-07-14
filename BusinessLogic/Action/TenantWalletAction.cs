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
   public class TenantWalletAction : ActionBase  
   {  
       public TenantWalletAction()  
       {  
       }  
       public TenantWalletAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<TenantWalletBusinessModel>> GetAll(  
           Expression<Func<TenantWalletBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantWalletDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<TenantWalletBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<TenantWalletBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantWalletDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<TenantWalletBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.TenantWalletDao.GetAllCount(filter);  
       }  
       public async Task<TenantWalletBusinessModel?> Get(Int64 input, string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantWalletDao.GetByKey(input, includeProperties);  
       }  
       public void Add(TenantWalletBusinessModel input)  
       {  
           TenantWalletBusinessRule obj = new TenantWalletBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TenantWalletDao.Create(input);  
       }  
       public void Modify(TenantWalletBusinessModel input)  
       {  
           TenantWalletBusinessRule obj = new TenantWalletBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TenantWalletDao.Update(input);  
       }  
       public void Remove(TenantWalletBusinessModel input)  
       {  
           TenantWalletBusinessRule obj = new TenantWalletBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TenantWalletDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.TenantWalletDao.Delete(input);  
       }  
       public void Save(TenantWalletBusinessModel input)  
       {  
           if (input.TenantWalletId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.TenantWalletId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
