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
   public class CurrencyAction : ActionBase  
   {  
       public CurrencyAction()  
       {  
       }  
       public CurrencyAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<CurrencyBusinessModel>> GetAll(  
           Expression<Func<CurrencyBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.CurrencyDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<CurrencyBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<CurrencyBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.CurrencyDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<CurrencyBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.CurrencyDao.GetAllCount(filter);  
       }  
       public async Task<CurrencyBusinessModel?> Get(Int64 input, string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.CurrencyDao.GetByKey(input, includeProperties);  
       }  
       public async Task<CurrencyBusinessModel> Add(CurrencyBusinessModel input)  
       {  
           CurrencyBusinessRule obj = new CurrencyBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.CurrencyDao.Create(input);  
       }  
       public void Modify(CurrencyBusinessModel input)  
       {  
           CurrencyBusinessRule obj = new CurrencyBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.CurrencyDao.Update(input);  
       }  
       public void Remove(CurrencyBusinessModel input)  
       {  
           CurrencyBusinessRule obj = new CurrencyBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.CurrencyDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.CurrencyDao.Delete(input);  
       }  
       public void Save(CurrencyBusinessModel input)  
       {  
           if (input.CurrencyId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.CurrencyId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
