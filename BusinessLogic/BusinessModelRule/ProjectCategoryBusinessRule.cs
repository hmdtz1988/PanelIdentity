using BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessModelRule
{
    public class ProjectCategoryBusinessRule : Decorator<ProjectCategoryBusinessModel>
    {
        public ProjectCategoryBusinessRule(ProjectCategoryBusinessModel input)
            : base(input)
        {
        }
        public override void AddBusinessRules()
        {
        }
    }
}
