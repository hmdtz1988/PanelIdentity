using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Service.Security
{
    public class UserLoginRequestResponseViewModel
    {
        public Int16 UserInfoType { get; set; }

        public IList<TenantBusinessModel> Tenants { get; set; }
    }
}
