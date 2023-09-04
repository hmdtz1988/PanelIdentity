using BusinessLogic.BusinessModelRules;
using BusinessModel;
using Core.Helper;
using DataTransferModel.ViewModel;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BusinessLogic.Action
{
    public class UserInfoAction : ActionBase  
   {  
       public UserInfoAction()  
       {  
       }  
       public UserInfoAction(FactoryContainer factoryContainer)  
       {  
           FactoryContainer = factoryContainer;  
       }  
       public async Task<IList<UserInfoBusinessModel>> GetAll(  
           Expression<Func<UserInfoBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.UserInfoDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<UserInfoBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<UserInfoBusinessModel, bool>>? filter = null,  
           string orderBy = "", string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.UserInfoDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<UserInfoBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.UserInfoDao.GetAllCount(filter);  
       }  
       public async Task<UserInfoBusinessModel?> Get(Int64 input, string? includeProperties = "")  
       {  
           return await FactoryContainer.Factory.UserInfoDao.GetByKey(input, includeProperties);  
       }  
       public async Task<UserInfoBusinessModel> Add(UserInfoBusinessModel input)  
       {
            var checkDublicate = await GetAll(x => x.MobileNo == input.MobileNo || (input.Email != "" && x.Email == input.Email) || (input.UserName != "" && x.UserName == input.UserName) || (input.NationalCode != "" && x.NationalCode == input.NationalCode),"", "UserTenants");

            if (checkDublicate != null && checkDublicate.Count > 0)
                throw new Exception("User exists");

            UserInfoBusinessRule obj = new UserInfoBusinessRule(input);  
            if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
                throw new Exception(obj.BrokenRules.ToString());

            if (!string.IsNullOrEmpty(input.Avatar))
            {
                var fileName = Guid.NewGuid().ToString() + ".jpeg";
                var fileInfo = new FileInfoViewModel() { FileName = fileName, Content = input.Avatar };

                var file = RequestResponseHelper.GetPostResponseHttpWebRequest<string>("https://attachment.futurewavesco.app/api/SaveFile/SaveImage", fileInfo, "");
                input.Avatar = "https://files.futurewavesco.app/" + fileName;
            }
            return await FactoryContainer.Factory.UserInfoDao.Create(input);  
       }  
       public void Modify(UserInfoBusinessModel input)  
       {  
           UserInfoBusinessRule obj = new UserInfoBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());
            if (!string.IsNullOrEmpty(input.Avatar) && !input.Avatar.StartsWith("https://files.futurewavesco.app/"))
            {
                var fileName = Guid.NewGuid().ToString() + ".jpeg";
                var fileInfo = new FileInfoViewModel() { FileName = fileName, Content = input.Avatar };

                var file = RequestResponseHelper.GetPostResponseHttpWebRequest<string>("https://attachment.futurewavesco.app/api/SaveFile/SaveImage", fileInfo, "");
                input.Avatar = "https://files.futurewavesco.app/" + fileName;
            }
            FactoryContainer.Factory.UserInfoDao.Update(input);  
       }  
       public void Remove(UserInfoBusinessModel input)  
       {  
           UserInfoBusinessRule obj = new UserInfoBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))  
               throw new Exception(obj.BrokenRules.ToString());  
           FactoryContainer.Factory.UserInfoDao.Delete(input);  
       }  
       public void Remove(Int64 input)  
       {  
           FactoryContainer.Factory.UserInfoDao.Delete(input);  
       }  
       public void Save(UserInfoBusinessModel input)  
       {  
           if (input.UserInfoId.HasValue == false)  
           {  
               Add(input);  
               return;  
           }  
           var result = Get(input.UserInfoId.Value);  
           if (result != null)  
               Modify(input);  
           else  
               Add(input);  
       }
        
        public async Task<UserInfoBusinessModel> UserLogin(string userName, string password)
        {
            try
            {
                var result = new UserInfoBusinessModel();
                var userInfo = await GetAll(x => x.UserName == userName && x.Password == password, "", "UserTenants.Tenant.TenantProjects.Project");
                if (userInfo != null && userInfo.Count > 0)
                {
                    var user = userInfo.FirstOrDefault();
                    user.ActivationCode = string.Empty;
                    Modify(user);
                    result = user;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserInfoBusinessModel> MobileLogin(string mobileNumber, string activeCode)
        {
            try
            {
                var result = new UserInfoBusinessModel();
                var userInfo = await GetAll(x => x.MobileNo == mobileNumber && x.ActivationCode == activeCode && x.ActivationCode != "", "", "UserTenants");
                if (userInfo != null && userInfo.Count > 0)
                {
                    var user = await Get(userInfo.FirstOrDefault().UserInfoId.Value, null);
                    user.ActivationCode = string.Empty;
                    Modify(user);
                    result = user;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }  
}  
