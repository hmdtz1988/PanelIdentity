using Core;

namespace BusinessModel
{  
	public class UserInfoBusinessModel : BusinessModelBase  
	{  
		public Int64? UserInfoId { get; set; }  
		public string NationalCode { get; set; }  
		public string UserName { get; set; }  
		public string MobileNo { get; set; }  
		public string Email { get; set; }  
		public string FirstName { get; set; }  
		public string LastName { get; set; }  
		public string Password { get; set; }  
		public string Avatar { get; set; }  
		public Int16 Status { get; set; }  
		public string ActivationCode { get; set; }  
		public Int64? RealPersonId { get; set; }  
		public bool IsFullAdmin { get; set; }  
		public bool IsActive { get; set; }  
		public bool IsLock { get; set; }  
		public DateTime? FromDate { get; set; }  
		public DateTime? ToDate { get; set; }  
		public TimeSpan? FromTime { get; set; }  
		public TimeSpan? ToTime { get; set; }  
		public DateTime CreationDate { get; set; }  
		public LoginHistoryBusinessModel? CurrentLogin { get; set; }
		public IList<UserTenantBusinessModel>? UserTenants { get; set; }
    }  
}  
