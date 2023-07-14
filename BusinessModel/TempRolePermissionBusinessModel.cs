using Core;

namespace BusinessModel
{  
	public class TempRolePermissionBusinessModel : BusinessModelBase  
	{  
		public Int64? TempRolePermissionId { get; set; }  
		public Int64 TempRoleId { get; set; }  
		public Int64 ServiceActionId { get; set; }  
		public DateTime CreationDate { get; set; }  
		public Int64 CreateById { get; set; }  
		public DateTime? UpdateDate { get; set; }  
		public Int64? UpdatedById { get; set; }  
		public bool IsDeleted { get; set; }  
		public DateTime? DeleteDate { get; set; }  
		public Int64? DeletedById { get; set; }  
	}  
}  
