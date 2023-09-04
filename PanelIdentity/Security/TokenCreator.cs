using BusinessLogic.Action;
using BusinessModel;
using Core.Extensions;
using Core.Utilities.Security.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;

namespace PanelIdentity.Security
{
    public class TokenCreator
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;
        //private JwtService jwtService;
        public TokenCreator(IHttpContextAccessor httpContextAccessor, ITokenHelper tokenHelper)
        {
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
            _tokenHelper = tokenHelper;
        }

        public async Task<string> CreateToken(UserInfoBusinessModel user, List<ProjectBusinessModel?>? projects, List<ServiceActionBusinessModel?>? serviceActions, Int64? tenantId, CountryBusinessModel? country)
        {
            try
            {
                var claims = new List<Claim> {
                new(ClaimTypeExtensions.TenantId, tenantId == null ? "" : tenantId.Value.ToString()),
                new(ClaimTypeExtensions.ActiveProjects, projects == null ? "" : JsonConvert.SerializeObject(projects)),
                new(ClaimTypeExtensions.Country, country == null ? "" : JsonConvert.SerializeObject(country)),
                new(ClaimTypeExtensions.UserTitle , user.FirstName + " " + user.LastName),
                new(ClaimTypeExtensions.ServiceActions , serviceActions == null ? "" : JsonConvert.SerializeObject(serviceActions))};

                TokenAction tokenAction = new TokenAction(_tokenHelper);
                return (await tokenAction.CreateAccessTokenAsync(user, claims, 600))?.Data?.Token;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
