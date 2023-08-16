using BusinessLogic.Interface;
using BusinessModel;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Models;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Action
{
    public class TokenAction : ITokenService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IRedisCacheService _cacheManager;

        public TokenAction(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _cacheManager = ServiceTool.ServiceProvider.GetService<IRedisCacheService>();
        }

        public async Task<DataResult<AccessToken>> CreateAccessTokenAsync(UserInfoBusinessModel user, IList<Claim> claims, int? tokenLifeTimeMinute = null)
        {
            try
            {
                UserInfoViewModel infoViewModel = new UserInfoViewModel() { 
                    ActivationCode = user.ActivationCode,
                    Avatar = user.Avatar,
                    CreationDate = user.CreationDate,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    FromDate = user.FromDate,
                    FromTime = user.FromTime,
                    IsActive = user.IsActive,
                    IsFullAdmin = user.IsFullAdmin,
                    IsLock=user.IsLock,
                    LastName = user.LastName,
                    MobileNo = user.MobileNo,
                    NationalCode = user.NationalCode,
                    Status = user.Status,
                    RealPersonId = user.RealPersonId,
                    ToDate = user.ToDate,
                    ToTime = user.ToTime,
                    UserInfoId = user.UserInfoId
                };
                var accessToken = _tokenHelper.CreateToken(infoViewModel, claims.ToList(), tokenLifeTimeMinute);
                return new SuccessDataResult<AccessToken>(accessToken);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(DateTime.Now.ToString("yyyy.MM.dd:HH:mm:ss") + " | TokenManager.CreateAccessTokenAsync() | Error : " + ex.Message);
                return new ErrorDataResult<AccessToken>(message: ex.Message);
            }
        }
    }
}
