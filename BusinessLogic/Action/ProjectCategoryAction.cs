using BusinessLogic.BusinessModelRule;
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
    public class ProjectCategoryAction : ActionBase
    {
        public ProjectCategoryAction()
        {
        }
        public ProjectCategoryAction(FactoryContainer factoryContainer)
        {
            FactoryContainer = factoryContainer;
        }
        public async Task<IList<ProjectCategoryBusinessModel>> GetAll(
            Expression<Func<ProjectCategoryBusinessModel, bool>>? filter = null,
            string orderBy = "", string? includeProperties = "")
        {
            return await FactoryContainer.Factory.ProjectCategoryDao.GetAll(filter, orderBy, includeProperties);
        }
        public async Task<IList<ProjectCategoryBusinessModel>> GetAll(int pageNumber, int pageSize,
            Expression<Func<ProjectCategoryBusinessModel, bool>>? filter = null,
            string orderBy = "", string? includeProperties = "")
        {
            return await FactoryContainer.Factory.ProjectCategoryDao.GetAll(pageNumber, pageSize, filter, orderBy, includeProperties
                );
        }
        public async Task<Int64> GetAllCount(Expression<Func<ProjectCategoryBusinessModel, bool>>? filter = null)
        {
            return await FactoryContainer.Factory.ProjectCategoryDao.GetAllCount(filter);
        }
        public async Task<ProjectCategoryBusinessModel?> Get(Int64 input, string? includeProperties = "")
        {
            return await FactoryContainer.Factory.ProjectCategoryDao.GetByKey(input, includeProperties);
        }
        public async Task<ProjectCategoryBusinessModel> Add(ProjectCategoryBusinessModel input)
        {
            ProjectCategoryBusinessRule obj = new ProjectCategoryBusinessRule(input);
            if (!obj.Validate(BusinessRules.BusinessObjectState.Add))
                throw new Exception(obj.BrokenRules.ToString());
            return await FactoryContainer.Factory.ProjectCategoryDao.Create(input);
        }
        public void Modify(ProjectCategoryBusinessModel input)
        {
            ProjectCategoryBusinessRule obj = new ProjectCategoryBusinessRule(input);
            if (!obj.Validate(BusinessRules.BusinessObjectState.Modify))
                throw new Exception(obj.BrokenRules.ToString());
            FactoryContainer.Factory.ProjectCategoryDao.Update(input);
        }
        public void Remove(ProjectCategoryBusinessModel input)
        {
            ProjectCategoryBusinessRule obj = new ProjectCategoryBusinessRule(input);
            if (!obj.Validate(BusinessRules.BusinessObjectState.Remove))
                throw new Exception(obj.BrokenRules.ToString());
            FactoryContainer.Factory.ProjectCategoryDao.Delete(input);
        }
        public void Remove(Int64 input)
        {
            FactoryContainer.Factory.ProjectCategoryDao.Delete(input);
        }
        public void Save(ProjectCategoryBusinessModel input)
        {
            if (input.ProjectCategoryId.HasValue == false)
            {
                Add(input);
                return;
            }
            var result = Get(input.ProjectCategoryId.Value);
            if (result != null)
                Modify(input);
            else
                Add(input);
        }
    }
}
