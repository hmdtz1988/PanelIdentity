using Core;

namespace BusinessModel
{  
	public class CurrencyBusinessModel : BusinessModelBase  
	{  
		public Int64? CurrencyId { get; set; }  
		public string Title { get; set; }  
		public string Symbol { get; set; }  
		public string Code { get; set; }  
	}  
}  
