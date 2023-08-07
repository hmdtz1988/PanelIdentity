using BusinessLogic.BusinessModelRules;
using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLogic.Action
{
    public class UserTenantAction : ActionBase
    {
        public UserTenantAction()
        {
        }
        public UserTenantAction(FactoryContainer factoryContainer)
        {
            FactoryContainer = factoryContainer;
        }
        public async Task<IList<UserTenantBusinessModel>> GetAll(
            Expression<Func<UserTenantBusinessModel, bool>>? filter = null,
            string orderBy = "", string includeProperties = "")
        {
            return await FactoryContainer.Factory.UserTenantDao.GetAll(filter, orderBy, includeProperties);
        }
        public async Task<IList<UserTenantBusinessModel>> GetAll(int pageNumber, int pageSize,
            Expression<Func<UserTenantBusinessModel, bool>>? filter = null,
            string orderBy = "", string includeProperties = "")
        {
            return await FactoryContainer.Factory.UserTenantDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties
                );
        }
        public async Task<Int64> GetAllCount(Expression<Func<UserTenantBusinessModel, bool>>? filter = null)
        {
            return await FactoryContainer.Factory.UserTenantDao.GetAllCount(filter);
        }
        public async Task<UserTenantBusinessModel?> Get(Int64 input, string includeProperties = "")
        {
            return await FactoryContainer.Factory.UserTenantDao.GetByKey(input, includeProperties);
        }
        public async Task<UserTenantBusinessModel> Add(UserTenantBusinessModel input)
        {
            UserTenantBusinessRule obj = new UserTenantBusinessRule(input);
            if (!obj.Validate(BusinessRules.BusinessObjectState.Add))
                throw new Exception(obj.BrokenRules.ToString());
            return await FactoryContainer.Factory.UserTenantDao.Create(input);
        }
        public void Modify(UserTenantBusinessModel input)
        {
            UserTenantBusinessRule obj = new UserTenantBusinessRule(input);
            if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))
                throw new Exception(obj.BrokenRules.ToString());
            FactoryContainer.Factory.UserTenantDao.Update(input);
        }
        public void Remove(UserTenantBusinessModel input)
        {
            UserTenantBusinessRule obj = new UserTenantBusinessRule(input);
            if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))
                throw new Exception(obj.BrokenRules.ToString());
            FactoryContainer.Factory.UserTenantDao.Delete(input);
        }
        public void Remove(Int64 input)
        {
            FactoryContainer.Factory.UserTenantDao.Delete(input);
        }
        public void Save(UserTenantBusinessModel input)
        {
            if (input.UserTenantId.HasValue == false)
            {
                Add(input);
                return;
            }
            var result = Get(input.UserTenantId.Value);
            if (result != null)
                Modify(input);
            else
                Add(input);
        }
    }
}
