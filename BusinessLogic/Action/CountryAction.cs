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
   public class CountryAction : ActionBase  
   {  
       public CountryAction()  
       {  
       }  
       public CountryAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<CountryBusinessModel>> GetAll(  
           Expression<Func<CountryBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.CountryDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<CountryBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<CountryBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.CountryDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<CountryBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.CountryDao.GetAllCount(filter);  
       }  
       public async Task<CountryBusinessModel?> Get(Int64 input, string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.CountryDao.GetByKey(input, includeProperties);  
       }  
       public async Task<CountryBusinessModel> Add(CountryBusinessModel input)  
       {  
           CountryBusinessRule obj = new CountryBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.CountryDao.Create(input);  
       }  
       public void Modify(CountryBusinessModel input)  
       {  
           CountryBusinessRule obj = new CountryBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.CountryDao.Update(input);  
       }  
       public void Remove(CountryBusinessModel input)  
       {  
           CountryBusinessRule obj = new CountryBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.CountryDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.CountryDao.Delete(input);  
       }  
       public void Save(CountryBusinessModel input)  
       {  
           if (input.CountryId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.CountryId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
