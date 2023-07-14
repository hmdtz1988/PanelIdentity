using Core;

namespace BusinessModel
{  
	public class RoleBusinessModel : BusinessModelBase  
	{  
		public Int64? RoleId { get; set; }  
		public Int64 ProjectId { get; set; }  
		public Int64 TenantId { get; set; }  
		public string Title { get; set; }  
		public string Description { get; set; }  
		public DateTime CreationDate { get; set; }  
		public Int64 CreateById { get; set; }  
		public DateTime? UpdateDate { get; set; }  
		public Int64? UpdatedById { get; set; }  
		public bool IsDeleted { get; set; }  
		public DateTime? DeleteDate { get; set; }  
		public Int64? DeletedById { get; set; }
        public virtual ProjectBusinessModel Project { get; set; } = null!;
        public virtual TenantBusinessModel Tenant { get; set; } = null!;

        public virtual ICollection<UserInRoleBusinessModel> UserInRoles { get; set; } = new List<UserInRoleBusinessModel>();
        public virtual ICollection<RolePermissionBusinessModel> RolePermissions { get; set; } = new List<RolePermissionBusinessModel>();

    }
}  
