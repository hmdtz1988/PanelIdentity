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
            CreateMap<UserDeviceBusinessModel, UserDevice>().ReverseMap();
            CreateMap<QRLoginTransactionBusinessModel, QRLoginTransaction>().ReverseMap();
            CreateMap<TempRoleBusinessModel, TempRole>().ReverseMap();
            CreateMap<LoginHistoryBusinessModel, LoginHistory>().ReverseMap();
            CreateMap<ServiceActionBusinessModel, ServiceAction>().ReverseMap();
            CreateMap<AccountTypeBusinessModel, AccountType>().ReverseMap();
            CreateMap<ProjectBusinessModel, Project>().ReverseMap();
            CreateMap<RoleBusinessModel, Role>().ReverseMap();
            CreateMap<ServiceBusinessModel, Service>().ReverseMap();
            CreateMap<CurrencyBusinessModel, Currency>().ReverseMap();
            CreateMap<ProjectAccountTypeBusinessModel, ProjectAccountType>().ReverseMap();
            CreateMap<RolePermissionBusinessModel, RolePermission>().ReverseMap();
            CreateMap<RoleServiceItemBusinessModel, RoleServiceItem>().ReverseMap();
            CreateMap<ServiceItemBusinessModel, ServiceItem>().ReverseMap();
            CreateMap<CountryBusinessModel, Country>().ReverseMap();
            CreateMap<TenantWalletTransactionBusinessModel, TenantWalletTransaction>().ReverseMap();
            CreateMap<TenantProjectBusinessModel, TenantProject>().ReverseMap();
            CreateMap<UserInfoBusinessModel, UserInfo>().ReverseMap();
            CreateMap<UserInRoleBusinessModel, UserInRole>().ReverseMap();
            CreateMap<UserPermissionBusinessModel, UserPermission>().ReverseMap();
            CreateMap<UserServiceItemBusinessModel, UserServiceItem>().ReverseMap();
            CreateMap<TenantBusinessModel, Tenant>().ReverseMap();
            CreateMap<LanguageBusinessModel, Language>().ReverseMap();
            CreateMap<TempRolePermissionBusinessModel, TempRolePermission>().ReverseMap();
            CreateMap<LoginStatusBusinessModel, LoginStatus>().ReverseMap();
            CreateMap<ProjectCategory, ProjectCategoryBusinessModel>().ReverseMap();
            CreateMap<UserTenant, UserTenantBusinessModel>().ReverseMap();
        }

    }
}
