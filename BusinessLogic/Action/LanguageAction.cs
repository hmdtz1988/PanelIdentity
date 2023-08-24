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
   public class LanguageAction : ActionBase  
   {  
       public LanguageAction()  
       {  
       }  
       public LanguageAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<LanguageBusinessModel>> GetAll(  
           Expression<Func<LanguageBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.LanguageDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<LanguageBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<LanguageBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.LanguageDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<LanguageBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.LanguageDao.GetAllCount(filter);  
       }  
       public async Task<LanguageBusinessModel?> Get(Int64 input, string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.LanguageDao.GetByKey(input, includeProperties);  
       }  
       public async Task<LanguageBusinessModel> Add(LanguageBusinessModel input)  
       {  
           LanguageBusinessRule obj = new LanguageBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.LanguageDao.Create(input);  
       }  
       public void Modify(LanguageBusinessModel input)  
       {  
           LanguageBusinessRule obj = new LanguageBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.LanguageDao.Update(input);  
       }  
       public void Remove(LanguageBusinessModel input)  
       {  
           LanguageBusinessRule obj = new LanguageBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.LanguageDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.LanguageDao.Delete(input);  
       }  
       public void Save(LanguageBusinessModel input)  
       {  
           if (input.LanguageId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.LanguageId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
