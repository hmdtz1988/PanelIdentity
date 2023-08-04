using DataAccess.Interfaces;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EntityFramework.Model;
using DataAccess.Interface;

namespace DataAccess.EntityFramework.MS_SQL
{
    public class DaoFactory : IDaoFactories
    {
        private Stack<IDbContextTransaction>? _transactions;

        private Stack<IDbContextTransaction> Transactions
        {
            get
            {
                if (_transactions == null)
                    _transactions = new Stack<IDbContextTransaction>();
                return _transactions;
            }
        }

        private DbContext DatabaseContext { get; set; }

        public DaoFactory()
        {
            ReNewDbContext();
        }

        public void BeginTransaction()
        {
            Transactions.Push(DatabaseContext.Database.BeginTransaction());
        }

        public void CommitTransaction()
        {
            if (Transactions.Count == 0)
                return;

            IDbContextTransaction txn = Transactions.Pop();
            txn.Commit();
        }

        public void RollbackTransaction()
        {
            if (Transactions.Count == 0)
                return;

            IDbContextTransaction txn = Transactions.Pop();
            try
            {
                txn.Rollback();
            }
            finally
            {
                ReNewDbContext();
            }
        }


        private void ReNewDbContext()
        {
            DatabaseContext = null;
            DatabaseContext = new PanelIdentityContext();
        }

        public IUserDeviceDao UserDeviceDao { get { return new UserDeviceDao(DatabaseContext); } }
        public IQRLoginTransactionDao QRLoginTransactionDao { get { return new QRLoginTransactionDao(DatabaseContext); } }
        public ILoginHistoryDao LoginHistoryDao { get { return new LoginHistoryDao(DatabaseContext); } }
        public ILanguageDao LanguageDao { get { return new LanguageDao(DatabaseContext); } }
        public ILoginStatusDao LoginStatusDao { get { return new LoginStatusDao(DatabaseContext); } }
        public IAccountTypeDao AccountTypeDao { get { return new AccountTypeDao(DatabaseContext); } }
        public IProjectDao ProjectDao { get { return new ProjectDao(DatabaseContext); } }
        public IRoleDao RoleDao { get { return new RoleDao(DatabaseContext); } }
        public IServiceDao ServiceDao { get { return new ServiceDao(DatabaseContext); } }
        public ICurrencyDao CurrencyDao { get { return new CurrencyDao(DatabaseContext); } }
        public IServiceActionDao ServiceActionDao { get { return new ServiceActionDao(DatabaseContext); } }
        public ITempRoleDao TempRoleDao { get { return new TempRoleDao(DatabaseContext); } }
        public IProjectAccountTypeDao ProjectAccountTypeDao { get { return new ProjectAccountTypeDao(DatabaseContext); } }
        public ITenantDao TenantDao { get { return new TenantDao(DatabaseContext); } }
        public IRolePermissionDao RolePermissionDao { get { return new RolePermissionDao(DatabaseContext); } }
        public IRoleServiceItemDao RoleServiceItemDao { get { return new RoleServiceItemDao(DatabaseContext); } }
        public IServiceItemDao ServiceItemDao { get { return new ServiceItemDao(DatabaseContext); } }
        public ITenantWalletDao TenantWalletDao { get { return new TenantWalletDao(DatabaseContext); } }
        public ITenantWalletTransactionDao TenantWalletTransactionDao { get { return new TenantWalletTransactionDao(DatabaseContext); } }
        public ITenentProjectDao TenentProjectDao { get { return new TenentProjectDao(DatabaseContext); } }
        public IUserInfoDao UserInfoDao { get { return new UserInfoDao(DatabaseContext); } }
        public IUserInRoleDao UserInRoleDao { get { return new UserInRoleDao(DatabaseContext); } }
        public IUserPermissionDao UserPermissionDao { get { return new UserPermissionDao(DatabaseContext); } }
        public IUserServiceItemDao UserServiceItemDao { get { return new UserServiceItemDao(DatabaseContext); } }
        public ITempRolePermissionDao TempRolePermissionDao { get { return new TempRolePermissionDao(DatabaseContext); } }

        public IProjectCategoryDao ProjectCategoryDao { get { return new ProjectCategoryDao(DatabaseContext); } }

        
    }
}
