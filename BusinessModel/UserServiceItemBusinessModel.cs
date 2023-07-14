using Core;

namespace BusinessModel
{  
	public class UserServiceItemBusinessModel : BusinessModelBase  
	{  
		public Int64? UserServiceItemId { get; set; }  
		public Int64 UserInfoId { get; set; }  
		public Int64 ServiceItemId { get; set; }  
		public DateTime CreationDate { get; set; }  
		public Int64 CreateById { get; set; }  
		public DateTime? UpdateDate { get; set; }  
		public Int64? UpdatedById { get; set; }  
		public bool IsDeleted { get; set; }  
		public DateTime? DeleteDate { get; set; }  
		public Int64? DeletedById { get; set; }  
	}  
}  
