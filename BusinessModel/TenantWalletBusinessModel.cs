using Core;

namespace BusinessModel
{  
	public class TenantWalletBusinessModel : BusinessModelBase  
	{  
		public Int64? TenantWalletId { get; set; }  
		public Int64 TenantId { get; set; }  
		public Int64 CurrencyId { get; set; }  
		public string WalletNo { get; set; }  
		public bool IsActive { get; set; }  
		public DateTime CreationDate { get; set; }  
	}  
}  
