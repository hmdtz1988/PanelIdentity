using Core;

namespace BusinessModel
{  
	public class TenantBusinessModel : BusinessModelBase  
	{  
		public Int64? TenantId { get; set; }  
		public string Title { get; set; }  
		public Int64? ParentId { get; set; }
		public bool IsDemo { get; set; }  
		public string Description { get; set; }  
		public string InviteKey { get; set; }
		public bool IsActive { get; set; }  
		public bool HasDebit { get; set; }  
		public bool IsMain { get; set; }  
		public DateTime? ExpireDate { get; set; }  
		public Int64? CompanyId { get; set; }  
		public string Logo { get; set; }  
		public DateTime CreationDate { get; set; }  
		public Int64 CreateById { get; set; }  
		public bool IsDeleted { get; set; }  
		public DateTime? DeleteDate { get; set; }  
		public Int64? DeletedById { get; set; }  
	}  
}  
