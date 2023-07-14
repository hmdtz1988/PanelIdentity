using Core;

namespace BusinessModel
{  
	public class UserDeviceBusinessModel : BusinessModelBase  
	{  
		public Int64? UserDeviceId { get; set; }  
		public Int64? UserInfoId { get; set; }  
		public string DeviceKey { get; set; }  
		public string DeviceLocalKey { get; set; }  
		public string DeviceName { get; set; }  
		public string AppStoreId { get; set; }  
		public string DeviceType { get; set; }  
		public string Version { get; set; }  
		public bool IsActive { get; set; }  
		public DateTime CreationDate { get; set; }  
		public DateTime UpdateDate { get; set; }  
	}  
}  
