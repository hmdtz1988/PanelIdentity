﻿using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLogic.BusinessModelRules
{
    public class UserTenantBusinessRule : Decorator<UserTenantBusinessModel>
    {
        public UserTenantBusinessRule(UserTenantBusinessModel input)
            : base(input)
        {
        }
        public override void AddBusinessRules()
        {
        }
    }
}
