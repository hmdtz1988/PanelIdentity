using Core;

namespace BusinessModel
{  
	public class LoginHistoryBusinessModel : BusinessModelBase  
	{  
		public Int64? LoginHistoryId { get; set; }  
		public Int64 UserInfoId { get; set; }  
		public Int64 TenantId { get; set; }  
		public Int64 ProjectId { get; set; }  
		public Int64 LoginStatusId { get; set; }  
		public string UserHostAddress { get; set; }  
		public string Token { get; set; }  
		public string Version { get; set; }  
		public string Chanel { get; set; }  
		public DateTime? LoginDateTime { get; set; }  
		public DateTime? LogoutDateTime { get; set; }  
		public DateTime? ExpireDateTime { get; set; }  
		public DateTime CreationDate { get; set; }
        public virtual LoginStatusBusinessModel LoginStatus { get; set; } = null!;

        public virtual ProjectBusinessModel Project { get; set; } = null!;

        public virtual TenantBusinessModel Tenant { get; set; } = null!;

        public virtual UserInfoBusinessModel UserInfo { get; set; } = null!;
    }  
}  
