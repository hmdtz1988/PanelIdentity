using Core;

namespace BusinessModel
{  
	public class UserPermissionBusinessModel : BusinessModelBase  
	{  
		public Int64? UserPermissionId { get; set; }  
		public Int64 UserInfoId { get; set; }  
		public Int64 TenantId { get; set; }  
		public Int64 ServiceActionId { get; set; }  
		public bool IsDenied { get; set; }  
		public DateTime CreationDate { get; set; }  
		public Int64 CreateById { get; set; }  
		public DateTime? UpdateDate { get; set; }  
		public Int64? UpdatedById { get; set; }  
		public bool IsDeleted { get; set; }  
		public DateTime? DeleteDate { get; set; }  
		public Int64? DeletedById { get; set; }  
	}  
}  
