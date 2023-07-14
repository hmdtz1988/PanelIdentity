using Core;

namespace BusinessModel
{  
	public class TenantProjectBusinessModel : BusinessModelBase  
	{  
		public Int64? TenentProjectId { get; set; }  
		public Int64 TenantId { get; set; }  
		public Int64 ProjectId { get; set; }  
		public DateTime StartDate { get; set; }  
		public Int64 AccountTypeId { get; set; }  
		public bool IsActice { get; set; }  
	}  
}  
