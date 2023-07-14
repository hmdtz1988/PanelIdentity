using BusinessModel;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;  
namespace BusinessLogic.BusinessModelRules  
{  
    public class ProjectBusinessRule : Decorator<ProjectBusinessModel>  
    {  
        public ProjectBusinessRule(ProjectBusinessModel input)  
            : base(input)  
        {  
        }  
        public override void AddBusinessRules()  
        {  
        }  
    }  
}  
