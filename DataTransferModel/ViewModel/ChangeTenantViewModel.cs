using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModel.ViewModel
{
    public class ChangeTenantViewModel
    {
        public Int64 TenantId { get; set; }
        public string Token { get; set; }
        public Guid AccessToken { get; set; }
    }
}
