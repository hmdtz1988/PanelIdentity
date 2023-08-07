using BusinessLogic.BusinessModelRules;
using BusinessModel;
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
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.UserInfoDao.GetAll(filter, orderBy, includeProperties);  
       }  
       public async Task<IList<UserInfoBusinessModel>> GetAll(int pageNumber, int pageSize,  
           Expression<Func<UserInfoBusinessModel, bool>>? filter = null,  
           string orderBy = "", string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.UserInfoDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties  
               );  
       }  
       public async Task<Int64> GetAllCount(Expression<Func<UserInfoBusinessModel, bool>>? filter = null)  
       {  
           return await FactoryContainer.Factory.UserInfoDao.GetAllCount(filter);  
       }  
       public async Task<UserInfoBusinessModel?> Get(Int64 input, string includeProperties = "")  
       {  
           return await FactoryContainer.Factory.UserInfoDao.GetByKey(input, includeProperties);  
       }  
       public async Task<UserInfoBusinessModel> Add(UserInfoBusinessModel input)  
       {
            var checkDublicate = await GetAll(x => x.MobileNo == input.MobileNo || (input.Email != "" && x.Email == input.Email) || (input.UserName != "" && x.UserName == input.UserName) || (input.NationalCode != "" && x.NationalCode == input.NationalCode),"", "UserTenants");

            if (checkDublicate != null && checkDublicate.Count > 0)
                return checkDublicate.FirstOrDefault();

            UserInfoBusinessRule obj = new UserInfoBusinessRule(input);  
            if (!obj.Validate(BusinessRules.BusinessObjectState.Add))  
                throw new Exception(obj.BrokenRules.ToString());  
            return await FactoryContainer.Factory.UserInfoDao.Create(input);  
       }  
       public void Modify(UserInfoBusinessModel input)  
       {  
           UserInfoBusinessRule obj = new UserInfoBusinessRule(input);  
           if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))  
               throw new Exception(obj.BrokenRules.ToString());  
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
   }  
}  
