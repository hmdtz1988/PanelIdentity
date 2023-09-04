using Core;

namespace BusinessModel
{  
	public class TenantWalletTransactionBusinessModel : BusinessModelBase  
	{
        public long? TenantWalletTransactionId { get; set; }

        public long TenantId { get; set; }

        public int CurrencyId { get; set; }

        public long? ParentId { get; set; }

        public byte TransactionType { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        public string? Description { get; set; }

        public string? TransactionNumber { get; set; }

        public string? RefrenceNumber { get; set; }

        public DateTime? TransactionDate { get; set; }

        public byte? TransactionStatus { get; set; }

        public string? AuthCode { get; set; }

        public string? BatchNo { get; set; }

        public string? HostDate { get; set; }

        public string? ResultCode { get; set; }

        public string? ResultDetail { get; set; }

        public string? PanCode { get; set; }

        public long? CreateById { get; set; }

        public DateTime CreationDate { get; set; }

        public long? UpdateById { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public byte? IsDeleted { get; set; }

        public long? DeleteById { get; set; }

        public DateTime? DeletedDate { get; set; }
    }  
}  
