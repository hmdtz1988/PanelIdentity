using Core;
using StackExchange.Redis;

namespace BusinessModel
{  
	public class RolePermissionBusinessModel : BusinessModelBase  
	{  
		public Int64? RolePermissionId { get; set; }  
		public Int64 RoleId { get; set; }  
		public Int64 TenantId { get; set; }  
		public Int64 ServiceActionId { get; set; }  
		public DateTime CreationDate { get; set; }  
		public Int64 CreateById { get; set; }  
		public DateTime? UpdateDate { get; set; }  
		public Int64? UpdatedById { get; set; }  
		public bool IsDeleted { get; set; }  
		public DateTime? DeleteDate { get; set; }  
		public Int64? DeletedById { get; set; }
        public virtual ServiceActionBusinessModel? ServiceAction { get; set; } = null!;
        public virtual TenantBusinessModel? Tenant { get; set; } = null!;
        
    }  
}  
