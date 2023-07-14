using BusinessModel;
using System.Threading.Tasks;

namespace PanelIdentity.Security.JWTService
{
    public interface IJwtService
    {
        Task<string> Generate(UserInfoBusinessModel user);
    }
}