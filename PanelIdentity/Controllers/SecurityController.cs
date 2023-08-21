using BusinessLogic.Action;
using BusinessModel;
using Core.Extensions;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using DataTransferModel.ViewModel;
using ExternalServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PanelIdentity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Service.Security;
using IResult = Core.Utilities.Results.IResult;
namespace PanelIdentity.Controllers
{
    [Route("api/Security/[action]")]
    public class SecurityController : BaseApiController
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        private TokenCreator _tokenCreator;
        //private JwtService jwtService;
        public SecurityController(IHttpContextAccessor httpContextAccessor, ITokenHelper tokenHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            _tokenHelper = tokenHelper;
            _tokenCreator = new TokenCreator(httpContextAccessor, tokenHelper);
        }


        [HttpPost, HttpOptions]
        public async Task<IResult> MobileLogin([FromBody] MobileLoginViewModel input)
        {
            var loginHistory = new LoginHistoryBusinessModel();
            loginHistory.TenantId = input.TenantId;
            try
            {
                var userAction = new UserInfoAction();
                var userController = new UserInfoController(_httpContextAccessor);
                var user = await userController.MobileLogin(input.MobileNumber, input.ActiveCode);
                if (user.UserInfoId == null)
                {
                    return new ErrorDataResult<UserLoginViewModel>("UsernameOrPasswordIsInvalid");
                }

                user = await userAction.Get(user.UserInfoId.Value, "UserTenants");

                if (user.UserTenants?.Count > 0 && input.TenantId == null)
                    return new ErrorDataResult<UserLoginViewModel>("Tenant Not Selected");

                if (input.TenantId != null && !user.UserTenants.Select(x=> x.TenantId).Contains(input.TenantId.Value))
                    return new ErrorDataResult<UserLoginViewModel>("Access Denied", 404, "404");

                loginHistory.UserInfoId = user.UserInfoId.Value;
                loginHistory.Token = _tokenCreator.CreateToken(user, null, null, input.TenantId).Result;
                loginHistory.LoginDateTime = DateTime.Now;
                loginHistory.ExpireDateTime = DateTime.Now.AddHours(16);
                if (user == null)
                {
                    loginHistory.LoginStatusId = 2;
                    return new ErrorDataResult<UserLoginViewModel>("UsernameOrPasswordIsInvalid");
                }

                if (!user.IsActive)
                {
                    return new ErrorDataResult<UserLoginViewModel>("LoginStatus_InactiveUser");
                }
                if (user.IsLock)
                {
                    return new ErrorDataResult<UserLoginViewModel>("LoginStatus_LockUser");
                }
                loginHistory.LoginStatusId = 1;
                loginHistory.AccessToken = Guid.NewGuid();
                PostLoginHistory(loginHistory);
                user.CurrentLogin = loginHistory;
                var result = new UserLoginViewModel() { UserInfoId = user.UserInfoId.Value, Avatar = user.Avatar, ExpireDate = loginHistory.ExpireDateTime, LoginDate = loginHistory.CreationDate, AccessToken = loginHistory.AccessToken, Token = loginHistory.Token, UserFullTitle = user.FirstName + " " + user.LastName, UserName = user.UserName };
                return new SuccessDataResult<UserLoginViewModel>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<UserInfoBusinessModel>(ex.Message);
            }
        }


        [HttpPost, HttpOptions]
        public async Task<IResult> UserLogin([FromBody] UserNameLoginViewModel input)
        {
            var loginHistory = new LoginHistoryBusinessModel();
            try
            {
                var userAction = new UserInfoAction();
                var userController = new UserInfoController(_httpContextAccessor);
                var user = await userController.UserLogin(input.UserName, input.Password);
                if (user.UserInfoId == null)
                {
                    return new ErrorDataResult<UserLoginViewModel>("UsernameOrPasswordIsInvalid");
                }


                if (user.UserTenants?.Count > 0 && input.TenantId == null)
                    return new ErrorDataResult<UserLoginViewModel>("Tenant Not Selected");

                if (input.TenantId != null && !user.UserTenants.Select(x => x.TenantId).Contains(input.TenantId.Value))
                    return new ErrorDataResult<UserLoginViewModel>("Access Denied", 404, "404");


                user = await userAction.Get(user.UserInfoId.Value);
                loginHistory.UserInfoId = user.UserInfoId.Value;
                loginHistory.Token = _tokenCreator.CreateToken(user, null, null, input.TenantId).Result;
                loginHistory.LoginDateTime = DateTime.Now;
                loginHistory.ExpireDateTime = DateTime.Now.AddHours(16);
                loginHistory.TenantId = input.TenantId;
                if (user == null)
                {
                    return new ErrorDataResult<UserLoginViewModel>("UsernameOrPasswordIsInvalid");
                }

                if (!user.IsActive)
                {
                    return new ErrorDataResult<UserLoginViewModel>("LoginStatus_InactiveUser");
                }
                if (user.IsLock)
                {
                    return new ErrorDataResult<UserLoginViewModel>("LoginStatus_LockUser");
                }
                loginHistory.LoginStatusId = 1;
                loginHistory.AccessToken = Guid.NewGuid();
                user.CurrentLogin = loginHistory;
                PostLoginHistory(loginHistory);
                var result = new UserLoginViewModel() { UserInfoId = user.UserInfoId.Value, AccessToken = loginHistory.AccessToken, ExpireDate = loginHistory.ExpireDateTime, LoginDate = loginHistory.CreationDate, Avatar = user.Avatar, Token = loginHistory.Token, UserFullTitle = user.FirstName + " " + user.LastName, UserName = user.UserName };
                return new SuccessDataResult<UserLoginViewModel>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<UserInfoBusinessModel>(ex.Message);
            }
        }



        [HttpPost, HttpOptions]
        public async Task<IResult> LoginRequest([FromBody] SMSRequestViewModel input)
        {
            
            var loginHistory = new LoginHistoryBusinessModel();
            try
            {
                var userAction = new UserInfoAction();
                var sendSMSService = new SendSMSService();
                UserLoginRequestResponseViewModel result = new UserLoginRequestResponseViewModel();
                var mobileNumber = input.UserInfo;
                var userbyMobile = await userAction.GetAll(x => x.MobileNo == mobileNumber);
                result = new UserLoginRequestResponseViewModel();
                result.Tenants = new List<TenantBusinessModel>();
                if (userbyMobile != null && userbyMobile.Count > 0)
                {
                    Random rnd = new Random();
                    var disposablePassword = rnd.Next(13024, 100000);
                    var user = await userAction.Get(userbyMobile.FirstOrDefault().UserInfoId.Value, "UserTenants.Tenant");
                    user.ActivationCode = disposablePassword.ToString();
                    userAction.Modify(user);
                    List<String> str = new List<string>();
                    var sendData = sendSMSService.VerifySMS(mobileNumber, (user.FirstName + "" + user.LastName).Replace(" ","").Trim() ,disposablePassword.ToString());
                    if (sendData.Id != null)
                    {
                        result.Tenants = user.UserTenants?.Select(x=> x.Tenant).ToList(); // TODO IMPORTANT
                        result.UserInfoType = 1;
                        return new SuccessDataResult<UserLoginRequestResponseViewModel>(result);
                    }
                    else
                        return new ErrorDataResult<UserLoginRequestResponseViewModel>("SMS Sender Error");
                }
                else
                {
                    var userName = input.UserInfo;
                    var userbyName = await userAction.GetAll(x => x.UserName == userName, "", "UserTenants.Tenant");
                    if (userbyName != null && userbyName.Count != 0)
                    {
                        var user = userbyName.FirstOrDefault();
                        result.Tenants = userbyName.FirstOrDefault().UserTenants?.Select(x => x.Tenant).ToList(); // TODO IMPORTANT
                        result.UserInfoType = 2;
                        return new SuccessDataResult<UserLoginRequestResponseViewModel>(result);
                    }
                    else
                        return new ErrorDataResult<UserLoginRequestResponseViewModel>("USERNOTFOUND");
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<UserLoginRequestResponseViewModel>("USERNOTFOUND");
            }
        }

        [HttpGet, HttpOptions]
        public async Task<LoginHistoryBusinessModel> Authentication([FromRoute] string id)
        {
            try
            {
                var guid = id;
                var loginHistoryAction = new LoginHistoryAction();
                IList<LoginHistoryBusinessModel> result = new List<LoginHistoryBusinessModel>();
                result = await loginHistoryAction.GetAll();
                result = result.Where(x => x.Token == guid).ToList();
                if (result.Count == 0)
                    return null;

                if (result.FirstOrDefault()?.ExpireDateTime <= DateTime.Now)
                    return null;

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ServerException(ex);
            }
        }

        [HttpGet]
        public async Task<LoginHistoryBusinessModel> Logout([FromBody] string input)
        {

            var loginHistory = new LoginHistoryBusinessModel();
            try
            {
                var loginHistoryAction = new LoginHistoryAction();
                IList<LoginHistoryBusinessModel> result = new List<LoginHistoryBusinessModel>();
                result = await loginHistoryAction.GetAll();
                result = result.Where(x => x.Token == input && x.LogoutDateTime == null).ToList();
                if (result.Count == 0)
                    return null;
                var last = await loginHistoryAction.Get(result.FirstOrDefault().LoginHistoryId.Value);
                last.LogoutDateTime = DateTime.Now;
                loginHistoryAction.Modify(last);
                return null;
            }
            catch (Exception ex)
            {
                throw ServerException(ex);
            }

        }

        private LoginHistoryBusinessModel PostLoginHistory(LoginHistoryBusinessModel input)
        {
            try
            {
                input.ProjectId = 1;
                var action = new LoginHistoryAction();
                return action.Add(input);
            }
            catch (Exception ex)
            {
                throw ServerException(ex);
            }
        }
        
    }
}