using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessModel;
using DataAccess.EntityFramework.Model;

namespace DataAccess.EntityFramework.MS_SQL
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserDeviceBusinessModel, UserDevice>();
            CreateMap<UserDevice, UserDeviceBusinessModel>();
            CreateMap<QRLoginTransactionBusinessModel, QRLoginTransaction>();
            CreateMap<QRLoginTransaction, QRLoginTransactionBusinessModel>();
            CreateMap<TempRoleBusinessModel, TempRole>();
            CreateMap<TempRole, TempRoleBusinessModel>();
            CreateMap<LoginHistoryBusinessModel, LoginHistory>();
            CreateMap<LoginHistory, LoginHistoryBusinessModel>();
            CreateMap<ServiceActionBusinessModel, ServiceAction>();
            CreateMap<ServiceAction, ServiceActionBusinessModel>();
            CreateMap<AccountTypeBusinessModel, AccountType>();
            CreateMap<AccountType, AccountTypeBusinessModel>();
            CreateMap<ProjectBusinessModel, Project>();
            CreateMap<Project, ProjectBusinessModel>();
            CreateMap<RoleBusinessModel, Role>();
            CreateMap<Role, RoleBusinessModel>();
            CreateMap<ServiceBusinessModel, Service>();
            CreateMap<Service, ServiceBusinessModel>();
            CreateMap<CurrencyBusinessModel, Currency>();
            CreateMap<Currency, CurrencyBusinessModel>();
            CreateMap<ProjectAccountTypeBusinessModel, ProjectAccountType>();
            CreateMap<ProjectAccountType, ProjectAccountTypeBusinessModel>();
            CreateMap<RolePermissionBusinessModel, RolePermission>();
            CreateMap<RolePermission, RolePermissionBusinessModel>();
            CreateMap<RoleServiceItemBusinessModel, RoleServiceItem>();
            CreateMap<RoleServiceItem, RoleServiceItemBusinessModel>();
            CreateMap<ServiceItemBusinessModel, ServiceItem>();
            CreateMap<ServiceItem, ServiceItemBusinessModel>();
            CreateMap<TenantWalletBusinessModel, TenantWallet>();
            CreateMap<TenantWallet, TenantWalletBusinessModel>();
            CreateMap<TenantWalletTransactionBusinessModel, TenantWalletTransaction>();
            CreateMap<TenantWalletTransaction, TenantWalletTransactionBusinessModel>();
            CreateMap<TenantProjectBusinessModel, TenentProject>();
            CreateMap<TenentProject, TenantProjectBusinessModel>();
            CreateMap<UserInfoBusinessModel, UserInfo>();
            CreateMap<UserInfo, UserInfoBusinessModel>();
            CreateMap<UserInRoleBusinessModel, UserInRole>();
            CreateMap<UserInRole, UserInRoleBusinessModel>();
            CreateMap<UserPermissionBusinessModel, UserPermission>();
            CreateMap<UserPermission, UserPermissionBusinessModel>();
            CreateMap<UserServiceItemBusinessModel, UserServiceItem>();
            CreateMap<UserServiceItem, UserServiceItemBusinessModel>();
            CreateMap<TenantBusinessModel, Tenant>();
            CreateMap<Tenant, TenantBusinessModel>();
            CreateMap<LanguageBusinessModel, Language>();
            CreateMap<Language, LanguageBusinessModel>();
            CreateMap<TempRolePermissionBusinessModel, TempRolePermission>();
            CreateMap<TempRolePermission, TempRolePermissionBusinessModel>();
            CreateMap<LoginStatusBusinessModel, LoginStatus>();
            CreateMap<LoginStatus, LoginStatusBusinessModel>();
        }

    }
}
