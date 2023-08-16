using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferModel.ViewModel
{
    public class UserLoginViewModel
    {
        public Guid? AccessToken { get; set; } = null;

        public Int64 UserInfoId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string UserFullTitle { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public string Avatar { get; set; } = string.Empty;

        public DateTime? LoginDate { get; set; }

        public DateTime? ExpireDate { get; set; }


    }
}
