using BusinessLogic.Action;
using BusinessModel;
using Core.Utilities.Results;
using ExternalServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Service.Security;
using IResult = Core.Utilities.Results.IResult;
namespace PanelIdentity.Controllers
{
    [Route("api/Security/[action]")]
    public class SecurityController : BaseApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        //private JwtService jwtService;
        public SecurityController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
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
                    return new ErrorDataResult<UserInfoBusinessModel>("UsernameOrPasswordIsInvalid");
                }

                user = await userAction.Get(user.UserInfoId.Value);
                loginHistory.UserInfoId = user.UserInfoId.Value;
                loginHistory.Token = Guid.NewGuid().ToString();
                loginHistory.LoginDateTime = DateTime.Now;
                loginHistory.ExpireDateTime = DateTime.Now.AddHours(16);
                if (user == null)
                {
                    loginHistory.LoginStatusId = 2;
                    return new ErrorDataResult<UserInfoBusinessModel>("UsernameOrPasswordIsInvalid");
                }

                if (!user.IsActive)
                {
                    return new ErrorDataResult<UserInfoBusinessModel>("LoginStatus_InactiveUser");
                }
                if (user.IsLock)
                {
                    return new ErrorDataResult<UserInfoBusinessModel>("LoginStatus_LockUser");
                }
                loginHistory.LoginStatusId = 1;
                PostLoginHistory(loginHistory);
                user.CurrentLogin = loginHistory;
                return new SuccessDataResult<UserInfoBusinessModel>(user);
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
                    return new ErrorDataResult<UserInfoBusinessModel>("UsernameOrPasswordIsInvalid");
                }

                user = await userAction.Get(user.UserInfoId.Value);
                loginHistory.UserInfoId = user.UserInfoId.Value;
                loginHistory.Token = Guid.NewGuid().ToString();
                loginHistory.LoginDateTime = DateTime.Now;
                loginHistory.ExpireDateTime = DateTime.Now.AddHours(16);
                loginHistory.TenantId = input.TenantId;
                if (user == null)
                {
                    return new ErrorDataResult<UserInfoBusinessModel>("UsernameOrPasswordIsInvalid");
                }

                if (!user.IsActive)
                {
                    return new ErrorDataResult<UserInfoBusinessModel>("LoginStatus_InactiveUser");
                }
                if (user.IsLock)
                {
                    return new ErrorDataResult<UserInfoBusinessModel>("LoginStatus_LockUser");
                }
                loginHistory.LoginStatusId = 1;

                user.CurrentLogin = loginHistory;
                PostLoginHistory(loginHistory);
                return new SuccessDataResult<UserInfoBusinessModel>(user);
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
                    if (sendData.IsCompleted)
                    {
                        result.Tenants = userbyMobile.FirstOrDefault().UserTenants?.Select(x=> x.Tenant).ToList(); // TODO IMPORTANT
                        result.UserInfoType = 1;
                        return new SuccessDataResult<UserLoginRequestResponseViewModel>(result);
                    }
                    else
                        return new ErrorDataResult<UserLoginRequestResponseViewModel>("کاربر دسترسی به هیچ شرکتی ندارد");
                }
                else
                {
                    var userName = input.UserInfo;
                    var userbyName = await userAction.GetAll(x => x.UserName == userName, "", "UserTenants.Tenant");
                    if (userbyName != null && userbyName.Count != 0)
                    {
                        var user = userbyName.FirstOrDefault();
                        result.Tenants = userbyMobile.FirstOrDefault().UserTenants?.Select(x => x.Tenant).ToList(); // TODO IMPORTANT
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