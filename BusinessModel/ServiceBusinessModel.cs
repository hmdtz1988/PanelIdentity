using Autofac.Core;
using Core;

namespace BusinessModel
{  
	public class ServiceBusinessModel : BusinessModelBase  
	{  
		public Int64? ServiceId { get; set; }  
		public Int64? ParentId { get; set; }  
		public Int64? ProjectId { get; set; }  
		public string TitleFa { get; set; }  
		public string TitleEn { get; set; }  
		public string TitleTr { get; set; }  
		public string TitleAr { get; set; }  
		public string TitleDu { get; set; }  
		public string TitleFr { get; set; }  
		public string Controller { get; set; }  
		public string Icon { get; set; }  
		public bool IsService { get; set; }  
		public Int64 ItemOrder { get; set; }  
		public DateTime CreationDate { get; set; }

        public virtual ICollection<ServiceBusinessModel>? InverseParent { get; set; } = new List<ServiceBusinessModel>();

        public virtual ICollection<ServiceActionBusinessModel>? ServiceActions { get; set; } = new List<ServiceActionBusinessModel>();

        public virtual ICollection<ServiceItemBusinessModel>? ServiceItems { get; set; } = new List<ServiceItemBusinessModel>();
    }  
}  
