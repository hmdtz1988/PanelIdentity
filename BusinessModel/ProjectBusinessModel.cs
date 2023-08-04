using Autofac.Core;
using Core;

namespace BusinessModel
{  
	public class ProjectBusinessModel : BusinessModelBase  
	{  
		public Int64? ProjectId { get; set; }  
		public string TitleFa { get; set; }  
		public string TitleEn { get; set; }  
		public string TitleTr { get; set; }  
		public string TitleAr { get; set; }  
		public string TitleDu { get; set; }  
		public string TitleFr { get; set; }  
		public string Url { get; set; }  
		public string Icon { get; set; }  
		public DateTime CreationDate { get; set; }

        public virtual ICollection<ServiceBusinessModel>? Services { get; set; } = new List<ServiceBusinessModel>();
        public virtual ICollection<ProjectAccountTypeBusinessModel>? ProjectAccountTypes { get; set; } = new List<ProjectAccountTypeBusinessModel>();
    }
}  
