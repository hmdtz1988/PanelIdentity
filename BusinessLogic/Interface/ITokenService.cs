using BusinessModel;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ITokenService
    {
        Task<DataResult<AccessToken>> CreateAccessTokenAsync(UserInfoBusinessModel user, IList<Claim> claims, int? tokenLifeTimeMinute = null);
    }
}
