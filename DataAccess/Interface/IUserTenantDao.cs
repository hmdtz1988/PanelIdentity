﻿using BusinessModel;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IUserTenantDao : IBaseInterfaceDao<UserTenantBusinessModel>
    {
    }
}
