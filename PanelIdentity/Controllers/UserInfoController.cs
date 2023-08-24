using BusinessLogic.Action;  
using Microsoft.AspNetCore.Mvc;  
using BusinessModel;  
using Core.Utilities.Results;  
using Core.Extensions;  
using IResult = Core.Utilities.Results.IResult;
using PanelIdentity.Security;

namespace PanelIdentity.Controllers  
{  
    [Route("api/UserInfo/[action]")]  
    public class UserInfoController : BaseApiController  
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        private UserInfoAction action = new UserInfoAction();

        public UserInfoController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }

        [HttpGet("{id}")]  
        public async Task<IResult> Get(Int64 id, string? includeProperties)   
        {   
            try   
            {   
                var data = await action.Get(id, includeProperties);   
                return new SuccessDataResult<UserInfoBusinessModel>(data, 1);  
            }   
            catch (Exception ex)   
            {   
                return new ErrorDataResult<UserInfoBusinessModel>(message: ServerException(ex).Message);  
            }   
        }   
        [HttpPost]    
        public async Task<IResult> Get([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetFilterExpression<UserInfoBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties)    
                    : await action.GetAll(GetFilterExpression<UserInfoBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties);    
                var count = await Count(model);  
                return new SuccessDataResult<IList<UserInfoBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserInfoBusinessModel>>(message: ServerException(ex).Message);  
            }    
        }    
        [HttpPost]    
        public async Task<IResult> Suggestion([FromBody] DataFilterWithPaging model)    
        {    
            try    
            {    
                var data = HasPaging(model)    
                    ? await action.GetAll(model.PageNumber, model.PageSize, GetSuggestionExpression<UserInfoBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties)    
                    : await action.GetAll(GetSuggestionExpression<UserInfoBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties);    
                var count = await Count(model);    
                return new SuccessDataResult<IList<UserInfoBusinessModel>>(data, count);  
            }    
            catch (Exception ex)    
            {    
                return new ErrorDataResult<IList<UserInfoBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpGet]    
        public async Task<IResult> GetAll()    
        {    
            try    
            {    
                var data = await action.GetAll(null, "");    
                return new SuccessDataResult<IList<UserInfoBusinessModel>>(data, data.Count);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserInfoBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        public async Task<IResult> Post([FromBody] UserInfoBusinessModel input)    
        {    
            try    
            {
                input.Password = MD5Security.GetMd5Hash(input.Password);
                input = await action.Add(input);  
                return new SuccessDataResult<UserInfoBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserInfoBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPut("{id}")]    
        public IResult Put( Int64 id, [FromBody] UserInfoBusinessModel input)    
        {    
            try    
            {    
                action.Modify(input);  
                return new SuccessDataResult<UserInfoBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<UserInfoBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpDelete("{id}")]    
        public IResult Delete(Int64 id)    
        {    
            try    
            {    
                var action = new UserInfoAction();    
                action.Remove(id);  
                return new SuccessResult();  
            }  
            catch (Exception ex)    
            {    
                return new ErrorDataResult<UserInfoBusinessModel>(message: ServerException(ex).Message);  
            }  
        }    
        [HttpPost]    
        private async Task<long> Count([FromBody] DataFilterWithPaging input)    
        {    
            try    
            {    
                var action = new UserInfoAction();    
                return await action.GetAllCount(GetFilterExpression<UserInfoBusinessModel>(input.Filters));    
            }    
            catch (Exception ex)    
            {    
                throw ServerException(ex);    
            }    
        }


        [HttpGet]
        public async Task<UserInfoBusinessModel> MobileLogin(string mobileNumber, string activeCode)
        {
            try
            {
                var result = new UserInfoBusinessModel();
                var action = new UserInfoAction();
                var userInfo = await action.GetAll(x => x.MobileNo == mobileNumber && x.ActivationCode == activeCode && x.ActivationCode != "","","UserTenants");
                if (userInfo != null && userInfo.Count > 0)
                {
                    var user = await action.Get(userInfo.FirstOrDefault().UserInfoId.Value, null);
                    user.ActivationCode = string.Empty;
                    action.Modify(user);
                    result = user;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ServerException(ex);
            }
        }

        [HttpGet]
        public async Task<UserInfoBusinessModel> UserLogin(string userName, string password)
        {
            try
            {
                var result = new UserInfoBusinessModel();
                var action = new UserInfoAction();
                var userInfo = await action.GetAll(x => x.UserName == userName && x.Password == Security.MD5Security.GetMd5Hash(password),"","UserTenants");
                if (userInfo != null && userInfo.Count > 0)
                {
                    var user = userInfo.FirstOrDefault();
                    user.ActivationCode = string.Empty;
                    action.Modify(user);
                    result = user;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ServerException(ex);
            }
        }
    }  
}  
