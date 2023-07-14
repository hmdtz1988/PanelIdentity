using Core;

namespace BusinessModel
{  
	public class ProjectAccountTypeBusinessModel : BusinessModelBase  
	{  
		public Int64? ProjectAccountTypeId { get; set; }  
		public Int64 ProjectId { get; set; }  
		public Int64 AccountTypeId { get; set; }  
		public Int16 PeriodType { get; set; }  
		public Int64 CurrencyId { get; set; }  
		public decimal Amount { get; set; }
        public virtual AccountTypeBusinessModel AccountType { get; set; } = null!;

        public virtual CurrencyBusinessModel Currency { get; set; } = null!;

        public virtual ProjectBusinessModel Project { get; set; } = null!;
    }  
}  
