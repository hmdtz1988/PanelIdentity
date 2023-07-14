using Core;

namespace BusinessModel
{  
	public class TempRoleBusinessModel : BusinessModelBase  
	{  
		public Int64? TempRoleId { get; set; }  
		public Int64 ProjectId { get; set; }  
		public string TitleFa { get; set; }  
		public string TitleAr { get; set; }  
		public string TitleEn { get; set; }  
		public string TitleTr { get; set; }  
		public string TitleDu { get; set; }  
		public string TitleFr { get; set; }  
		public string Description { get; set; }  
		public DateTime CreationDate { get; set; }  
		public Int64 CreateById { get; set; }  
		public DateTime? UpdateDate { get; set; }  
		public Int64? UpdatedById { get; set; }  
		public bool IsDeleted { get; set; }  
		public DateTime? DeleteDate { get; set; }  
		public Int64? DeletedById { get; set; }  
	}  
}  
