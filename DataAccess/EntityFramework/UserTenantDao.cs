using BusinessModel;
using DataAccess.EntityFramework.Model;
using DataAccess.EntityFramework.MS_SQL;
using DataAccess.Interface;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class UserTenantDao : DaoBaseClass<UserTenant, UserTenantBusinessModel>, IUserTenantDao
    {
        public UserTenantDao(DbContext context) : base(context, "UserTenantId")
        {
        }
    }
}
