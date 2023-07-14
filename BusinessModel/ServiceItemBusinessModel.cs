using Core;

namespace BusinessModel
{  
	public class ServiceItemBusinessModel : BusinessModelBase  
	{  
		public Int64? ServiceItemId { get; set; }  
		public Int64 ServiceId { get; set; }  
		public Int64 TenantId { get; set; }  
		public string PropertyName1 { get; set; }  
		public Int64 PropertyValue1 { get; set; }  
		public string PropertyName2 { get; set; }  
		public string PropertyValue2 { get; set; }  
		public DateTime CreationDate { get; set; }  
		public Int64 CreateById { get; set; }  
		public DateTime? UpdateDate { get; set; }  
		public Int64? UpdatedById { get; set; }  
		public bool IsDeleted { get; set; }  
		public DateTime? DeleteDate { get; set; }  
		public Int64? DeletedById { get; set; }  
	}  
}  
