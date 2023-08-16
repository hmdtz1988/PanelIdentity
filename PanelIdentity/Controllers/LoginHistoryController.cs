using BusinessLogic.Action;  
using Microsoft.AspNetCore.Mvc;  
using BusinessModel;  
using Core.Utilities.Results;  
using Core.Extensions;  
using IResult = Core.Utilities.Results.IResult;
using DataTransferModel.ViewModel;
using Core.Utilities.Security.Jwt;
using PanelIdentity.Security;
using DataAccess.EntityFramework.Model;

namespace PanelIdentity.Controllers  
{  
    [Route("api/LoginHistory/[action]")]  
    public class LoginHistoryController : BaseApiController  
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        private TokenCreator _tokenCreator;
        //private JwtService jwtService;
        public LoginHistoryController(IHttpContextAccessor httpContextAccessor, ITokenHelper tokenHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            _tokenHelper = tokenHelper;
            _tokenCreator = new TokenCreator(httpContextAccessor, tokenHelper);
        }



        private LoginHistoryAction action = new LoginHistoryAction();  
        [HttpGet("{accessToken}")]  
       public async Task<IResult> Get(Guid accessToken)   
       {   
           try   
           {   
               var data = await action.GetAll(x=> x.AccessToken == accessToken,"","UserInfo");
                if (data == null)
                    return new ErrorDataResult<UserLoginViewModel>(message: "Not Found");

                var loginHistory = data.FirstOrDefault();
                var result = new UserLoginViewModel() { UserInfoId = loginHistory.UserInfoId, ExpireDate = loginHistory.ExpireDateTime, LoginDate = loginHistory.CreationDate, AccessToken = accessToken, Avatar = loginHistory.UserInfo.Avatar, Token = loginHistory.Token, UserFullTitle = loginHistory.UserInfo.FirstName + " " + loginHistory.UserInfo.LastName, UserName = loginHistory.UserInfo.UserName };
                return new SuccessDataResult<UserLoginViewModel>(result, 1);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<LoginHistoryBusinessModel>(message: ServerException(ex).Message);
            }
        }
        [HttpPost]
        public async Task<IResult> Get([FromBody] DataFilterWithPaging model)
        {
            try
            {
                var data = HasPaging(model)
                ? await action.GetAll(model.PageNumber, model.PageSize, GetFilterExpression<LoginHistoryBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties)
                : await action.GetAll(GetFilterExpression<LoginHistoryBusinessModel>(model.Filters), model.OrderBy, model.IncludeProperties);
                var count = await Count(model);
                foreach (var item in data)
                {
                    item.Token = string.Empty;
                    item.LoginHistoryId = null;
                    item.AccessToken = null;
                }
                return new SuccessDataResult<IList<LoginHistoryBusinessModel>>(data, count);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<LoginHistoryBusinessModel>>(message: ServerException(ex).Message);
            }
        }
        [HttpPost]
        public async Task<IResult> RefreshToken([FromBody] LoginHistoryBusinessModel input)
        {
            try
            {
                input = action.Add(input);  
                return new SuccessDataResult<LoginHistoryBusinessModel>(input, 1);  
            }  
            catch (Exception ex)    
            {  
                return new ErrorDataResult<IList<LoginHistoryBusinessModel>>(message: ServerException(ex).Message);  
            }  
        }

        [HttpPost]
        public async Task<IResult> ChangeTenant([FromBody] ChangeTenantViewModel input)
        {
            try
            {
                var loginHistories = await action.GetAll(x=> x.AccessToken == input.AccessToken && x.Token == input.Token, "", "UserInfo.UserTenants");
                if (loginHistories == null || loginHistories.Count == 0) 
                    return new ErrorDataResult<IList<LoginHistoryBusinessModel>>(message: "Token Not Found");

                var loginHistory = loginHistories.FirstOrDefault();

                if (loginHistory.UserInfo?.UserTenants == null || !loginHistory.UserInfo.UserTenants.Select(x => x.TenantId).Contains(input.TenantId))
                    return new ErrorDataResult<IList<LoginHistoryBusinessModel>>(message: "Access Denied");

                loginHistory.TenantId = input.TenantId;
                loginHistory.Token = await _tokenCreator.CreateToken(loginHistory.UserInfo, null, null, input.TenantId);
                action.Modify(loginHistory);
                var result = new UserLoginViewModel() { UserInfoId = loginHistory.UserInfoId, ExpireDate = loginHistory.ExpireDateTime, LoginDate = loginHistory.CreationDate, AccessToken = input.AccessToken, Avatar = loginHistory.UserInfo.Avatar, Token = loginHistory.Token, UserFullTitle = loginHistory.UserInfo.FirstName + " " + loginHistory.UserInfo.LastName, UserName = loginHistory.UserInfo.UserName };
                return new SuccessDataResult<UserLoginViewModel>(result, 1);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<LoginHistoryBusinessModel>>(message: ServerException(ex).Message);
            }
        }
        private async Task<long> Count([FromBody] DataFilterWithPaging input)    
        {    
            try    
            {    
                var action = new LoginHistoryAction();    
                return await action.GetAllCount(GetFilterExpression<LoginHistoryBusinessModel>(input.Filters));    
            }    
            catch (Exception ex)    
            {    
                throw ServerException(ex);    
            }    
        }    
    }  
}  
