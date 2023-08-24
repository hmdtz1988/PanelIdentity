using BusinessLogic.BusinessModelRules;  
using BusinessModel;
using Core.Helper;
using DataTransferModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Linq.Expressions;  
using System.Text;  
using System.Threading.Tasks;  
namespace BusinessLogic.Action  
{  
   public class TenantAction : ActionBase  
   {  
       public TenantAction()  
       {  
       }  
       public TenantAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<TenantBusinessModel>> GetAll(  
           Expression<Func<TenantBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<TenantBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<TenantBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<TenantBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.TenantDao.GetAllCount(filter);  
       }  
       public async Task<TenantBusinessModel?> Get(Int64 input, string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.TenantDao.GetByKey(input, includeProperties);  
       }  
       public async Task<TenantBusinessModel> Add(TenantBusinessModel input)  
       {  
           TenantBusinessRule obj = new TenantBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
               throw new Exception(obj.BrokenRules.ToString());


            var fileName = Guid.NewGuid().ToString() + ".jpeg";
            var fileInfo = new FileInfoViewModel() { FileName = fileName, Content = input.Logo };

            var file = RequestResponseHelper.GetPostResponseHttpWebRequest<string>("https://attachment.futurewavesco.app/api/SaveFile/SaveImage", fileInfo, "");
            input.Logo = "https://files.futurewavesco.app/" + fileName;

            return await FactoryContainer.Factory.TenantDao.Create(input);  
       }  
       public void Modify(TenantBusinessModel input)  
       {  
           TenantBusinessRule obj = new TenantBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  

           if (!input.Logo.StartsWith("https://files.futurewavesco.app/"))
            {
                var fileName = Guid.NewGuid().ToString() + ".jpeg";
                var fileInfo = new FileInfoViewModel() { FileName = fileName, Content = input.Logo };

                var file = RequestResponseHelper.GetPostResponseHttpWebRequest<string>("https://attachment.futurewavesco.app/api/SaveFile/SaveImage", fileInfo, "");
                input.Logo = "https://files.futurewavesco.app/" + fileName;
            }
           FactoryContainer.Factory.TenantDao.Update(input);  
       }  
       public void Remove(TenantBusinessModel input)  
       {  
           TenantBusinessRule obj = new TenantBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.TenantDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.TenantDao.Delete(input);  
       }  
       public void Save(TenantBusinessModel input)  
       {  
           if (input.TenantId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.TenantId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }  
   }  
}  
