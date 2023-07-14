using Core;

namespace BusinessModel
{  
	public class ServiceActionBusinessModel : BusinessModelBase  
	{  
		public Int64? ServiceActionId { get; set; }  
		public Int64 ServiceId { get; set; }  
		public string TitleFa { get; set; }  
		public string TitleEn { get; set; }  
		public string TitleAr { get; set; }  
		public string TitleTr { get; set; }  
		public string TitleDu { get; set; }  
		public string TitleFr { get; set; }  
		public string ApiController { get; set; }  
		public string ApiService { get; set; }  
	}  
}  
