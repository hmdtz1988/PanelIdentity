using BusinessModel;
using DataAccess.EntityFramework.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = DataAccess.EntityFramework.Model;

namespace DataAccess.EntityFramework.MS_SQL
{
    public static class DaoMapper
    {
        private static ConcurrentBag<string> mapCollection = new ConcurrentBag<string>();

        public static string Map(Type sourceType, string propertyNames)
        {
            string result = string.Empty;
            string temp1;


            if (string.IsNullOrEmpty(propertyNames))
                return string.Empty;

            if (propertyNames.ToLower() == "ignoreInclude".ToLower())
                return string.Empty;


            foreach (var item in propertyNames.Split(','))
            {
                string itemFullName = sourceType.Name + "." + item;
                string[] itemSplit = item.Split('.');
                temp1 = string.Empty;

                if (!string.IsNullOrEmpty(result))
                    result += ",";

                if (itemSplit.Length > 1)
                {
                    var propertyInfo = sourceType.GetProperty(itemSplit[0].Trim());
                    Type propertyType;
                    if (propertyInfo == null)
                        continue;

                    if (propertyInfo.PropertyType.GenericTypeArguments != null && propertyInfo.PropertyType.GenericTypeArguments.Count() > 0)
                        propertyType = propertyInfo.PropertyType.GenericTypeArguments[0];
                    else
                        propertyType = propertyInfo.PropertyType;

                    for (var index = 1; index < itemSplit.Length; index++)
                        temp1 += "." + itemSplit[index];
                    if (temp1.StartsWith("."))
                        temp1 = temp1.Substring(1, temp1.Length - 1);

                    result += Map(sourceType, itemSplit[0]) + ".";
                    result += Map(propertyType, temp1);
                }
                else
                {
                    var map = mapCollection.Where(x => x.Contains(itemFullName + ";") || x.Contains(";" + itemFullName)).FirstOrDefault();

                    if (map != null)
                    {
                        string[] mapSplit = map.Split(';');

                        if (mapSplit.Length > 1)
                            if (mapSplit[0] == itemFullName)
                                temp1 = mapSplit[1];
                            else
                                temp1 = mapSplit[0];
                        else
                            temp1 = mapSplit[0];

                        for (int i = 1; i < temp1.Split('.').Length; i++)
                        {
                            if (i > 1)
                                result += ".";

                            result += temp1.Split('.')[i];
                        }
                    }
                    else
                        result += item;
                }
            }

            return result.Replace(".,", ",");
        }
        
        public static Type? Map(Type input)
        {
            Type result = input;
            switch (input.Name)
            {
                case "UserDeviceBusinessModel":
                    result = typeof(UserDevice);
                    break;
                case "UserDevice":
                    result = typeof(UserDeviceBusinessModel);
                    break;
                case "QRLoginTransactionBusinessModel":
                    result = typeof(QRLoginTransaction);
                    break;
                case "QRLoginTransaction":
                    result = typeof(QRLoginTransactionBusinessModel);
                    break;
                case "TempRoleBusinessModel":
                    result = typeof(TempRole);
                    break;
                case "TempRole":
                    result = typeof(TempRoleBusinessModel);
                    break;
                case "LoginHistoryBusinessModel":
                    result = typeof(LoginHistory);
                    break;
                case "LoginHistory":
                    result = typeof(LoginHistoryBusinessModel);
                    break;
                case "ServiceActionBusinessModel":
                    result = typeof(ServiceAction);
                    break;
                case "ServiceAction":
                    result = typeof(ServiceActionBusinessModel);
                    break;
                case "AccountTypeBusinessModel":
                    result = typeof(AccountType);
                    break;
                case "AccountType":
                    result = typeof(AccountTypeBusinessModel);
                    break;
                case "ProjectBusinessModel":
                    result = typeof(Project);
                    break;
                case "Project":
                    result = typeof(ProjectBusinessModel);
                    break;
                case "RoleBusinessModel":
                    result = typeof(Role);
                    break;
                case "Role":
                    result = typeof(RoleBusinessModel);
                    break;
                case "ServiceBusinessModel":
                    result = typeof(Service);
                    break;
                case "Service":
                    result = typeof(ServiceBusinessModel);
                    break;
                case "CurrencyBusinessModel":
                    result = typeof(Currency);
                    break;
                case "Currency":
                    result = typeof(CurrencyBusinessModel);
                    break;
                case "ProjectAccountTypeBusinessModel":
                    result = typeof(ProjectAccountType);
                    break;
                case "ProjectAccountType":
                    result = typeof(ProjectAccountTypeBusinessModel);
                    break;
                case "RolePermissionBusinessModel":
                    result = typeof(RolePermission);
                    break;
                case "RolePermission":
                    result = typeof(RolePermissionBusinessModel);
                    break;
                case "RoleServiceItemBusinessModel":
                    result = typeof(RoleServiceItem);
                    break;
                case "RoleServiceItem":
                    result = typeof(RoleServiceItemBusinessModel);
                    break;
                case "ServiceItemBusinessModel":
                    result = typeof(ServiceItem);
                    break;
                case "ServiceItem":
                    result = typeof(ServiceItemBusinessModel);
                    break;
                case "TenantWalletBusinessModel":
                    result = typeof(TenantWallet);
                    break;
                case "TenantWallet":
                    result = typeof(TenantWalletBusinessModel);
                    break;
                case "TenantWalletTransactionBusinessModel":
                    result = typeof(TenantWalletTransaction);
                    break;
                case "TenantWalletTransaction":
                    result = typeof(TenantWalletTransactionBusinessModel);
                    break;
                case "TenantProjectBusinessModel":
                    result = typeof(TenentProject);
                    break;
                case "TenentProject":
                    result = typeof(TenantProjectBusinessModel);
                    break;

                case "ProjectCategoryBusinessModel":
                    result = typeof(ProjectCategory);
                    break;
                case "ProjectCategory":
                    result = typeof(ProjectCategoryBusinessModel);
                    break;

                case "UserTenantBusinessModel":
                    result = typeof(UserTenant);
                    break;
                case "UserTenant":
                    result = typeof(UserTenantBusinessModel);
                    break;

                case "UserInfoBusinessModel":
                    result = typeof(UserInfo);
                    break;
                case "UserInfo":
                    result = typeof(UserInfoBusinessModel);
                    break;
                case "UserInRoleBusinessModel":
                    result = typeof(UserInRole);
                    break;
                case "UserInRole":
                    result = typeof(UserInRoleBusinessModel);
                    break;
                case "UserPermissionBusinessModel":
                    result = typeof(UserPermission);
                    break;
                case "UserPermission":
                    result = typeof(UserPermissionBusinessModel);
                    break;
                case "UserServiceItemBusinessModel":
                    result = typeof(UserServiceItem);
                    break;
                case "UserServiceItem":
                    result = typeof(UserServiceItemBusinessModel);
                    break;
                case "TenantBusinessModel":
                    result = typeof(Tenant);
                    break;
                case "Tenant":
                    result = typeof(TenantBusinessModel);
                    break;
                case "LanguageBusinessModel":
                    result = typeof(Language);
                    break;
                case "Language":
                    result = typeof(LanguageBusinessModel);
                    break;
                case "TempRolePermissionBusinessModel":
                    result = typeof(TempRolePermission);
                    break;
                case "TempRolePermission":
                    result = typeof(TempRolePermissionBusinessModel);
                    break;
                case "LoginStatusBusinessModel":
                    result = typeof(LoginStatus);
                    break;
                case "LoginStatus":
                    result = typeof(LoginStatusBusinessModel);
                    break;
                default :
                    break;
            }
            return result;
        }
        
    }
}
