using Core;

namespace BusinessModel
{  
	public class TenantBusinessModel : BusinessModelBase  
	{  
		public Int64? TenantId { get; set; }  
		public Int64? UserId { get; set; }
        public string? Title { get; set; }

        public long? ParentId { get; set; }

        public int? CountryId { get; set; }

        public int? LanguageId { get; set; }

        public int? CurrencyId { get; set; }

        public int? WalletNumber { get; set; }

        public string? InviteKey { get; set; }

        public bool IsDemo { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public bool HasDebit { get; set; }

        public bool IsMain { get; set; }

        public DateTime? ExpireDate { get; set; }

        public long? CompanyId { get; set; }

        public string? Logo { get; set; }

        public DateTime CreationDate { get; set; }

        public long CreateById { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeleteDate { get; set; }

        public long? DeletedById { get; set; }

        public virtual CountryBusinessModel? Country { get; set; }

        public virtual CurrencyBusinessModel? Currency { get; set; }

    }
}  
