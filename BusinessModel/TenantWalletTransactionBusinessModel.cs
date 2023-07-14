using Core;

namespace BusinessModel
{  
	public class TenantWalletTransactionBusinessModel : BusinessModelBase  
	{  
		public Int64? TenantWalletTransactionId { get; set; }  
		public Int64? ParentId { get; set; }  
		public Int16 TransactionType { get; set; }  
		public Int64 TenantWalletId { get; set; }  
		public decimal Debit { get; set; }  
		public decimal Credit { get; set; }  
		public string Description { get; set; }  
		public string TransactionNumber { get; set; }  
		public string RefrenceNumber { get; set; }  
		public DateTime? TransactionDate { get; set; }  
		public Int16? TransactionStatus { get; set; }  
		public string AuthCode { get; set; }  
		public string BatchNo { get; set; }  
		public string HostDate { get; set; }  
		public string ResultCode { get; set; }  
		public string ResultDetail { get; set; }  
		public string PanCode { get; set; }  
		public Int64? CreateById { get; set; }  
		public DateTime CreationDate { get; set; }  
		public Int64? UpdateById { get; set; }  
		public DateTime? UpdatedDate { get; set; }  
		public Int16? IsDeleted { get; set; }  
		public Int64? DeleteById { get; set; }  
		public DateTime? DeletedDate { get; set; }  
	}  
}  
