using DataAccess.Interface;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDaoFactories
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        IUserDeviceDao UserDeviceDao { get; }
        IQRLoginTransactionDao QRLoginTransactionDao { get; }
        ILoginHistoryDao LoginHistoryDao { get; }
        ILanguageDao LanguageDao { get; }
        ILoginStatusDao LoginStatusDao { get; }
        IAccountTypeDao AccountTypeDao { get; }
        IProjectDao ProjectDao { get; }
        IRoleDao RoleDao { get; }
        IServiceDao ServiceDao { get; }
        ICurrencyDao CurrencyDao { get; }
        IServiceActionDao ServiceActionDao { get; }
        ITempRoleDao TempRoleDao { get; }
        IProjectAccountTypeDao ProjectAccountTypeDao { get; }
        ITenantDao TenantDao { get; }
        IRolePermissionDao RolePermissionDao { get; }
        IRoleServiceItemDao RoleServiceItemDao { get; }
        IServiceItemDao ServiceItemDao { get; }
        ICountryDao CountryDao { get; }
        ITenantWalletTransactionDao TenantWalletTransactionDao { get; }
        ITenantProjectDao TenantProjectDao { get; }
        IUserInfoDao UserInfoDao { get; }
        IUserInRoleDao UserInRoleDao { get; }
        IUserPermissionDao UserPermissionDao { get; }
        IUserServiceItemDao UserServiceItemDao { get; }
        ITempRolePermissionDao TempRolePermissionDao { get; }
        IProjectCategoryDao ProjectCategoryDao { get; }

        IUserTenantDao UserTenantDao { get; }
    }
}
