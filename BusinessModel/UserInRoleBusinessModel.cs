using Core;

namespace BusinessModel
{  
	public class UserInRoleBusinessModel : BusinessModelBase  
	{  
		public Int64? UserInRoleId { get; set; }  
		public Int64 RoleId { get; set; }  
		public Int64 UserInfoId { get; set; }  
		public Int64 TenantId { get; set; }  
		public DateTime CreationDate { get; set; }  
		public Int64 CreateById { get; set; }  
		public DateTime? UpdateDate { get; set; }  
		public Int64? UpdatedById { get; set; }  
		public bool IsDeleted { get; set; }  
		public DateTime? DeleteDate { get; set; }  
		public Int64? DeletedById { get; set; }  

		public UserInfoBusinessModel? UserInfo { get; set; }
	}  
}  
