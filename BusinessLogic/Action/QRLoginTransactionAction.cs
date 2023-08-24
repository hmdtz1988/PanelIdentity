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
   public class QRLoginTransactionAction : ActionBase  
   {  
       public QRLoginTransactionAction()  
       {  
       }  
       public QRLoginTransactionAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<QRLoginTransactionBusinessModel>> GetAll(  
           Expression<Func<QRLoginTransactionBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.QRLoginTransactionDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<QRLoginTransactionBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<QRLoginTransactionBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.QRLoginTransactionDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<QRLoginTransactionBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.QRLoginTransactionDao.GetAllCount(filter);  
       }  
       public async Task<QRLoginTransactionBusinessModel?> Get(Int64 input, string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.QRLoginTransactionDao.GetByKey(input, includeProperties);  
       }  
       public async Task<QRLoginTransactionBusinessModel> Add(QRLoginTransactionBusinessModel input)  
       {  
           QRLoginTransactionBusinessRule obj = new QRLoginTransactionBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());  
           return await FactoryContainer.Factory.QRLoginTransactionDao.Create(input);  
       }  
       public void Modify(QRLoginTransactionBusinessModel input)  
       {  
           QRLoginTransactionBusinessRule obj = new QRLoginTransactionBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.QRLoginTransactionDao.Update(input);  
       }  
       public void Remove(QRLoginTransactionBusinessModel input)  
       {  
           QRLoginTransactionBusinessRule obj = new QRLoginTransactionBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.QRLoginTransactionDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.QRLoginTransactionDao.Delete(input);  
       }  
       public void Save(QRLoginTransactionBusinessModel input)  
       {  
           if (input.QRLoginTransactionId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.QRLoginTransactionId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
