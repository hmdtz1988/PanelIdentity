using Core;

namespace BusinessModel
{  
	public class QRLoginTransactionBusinessModel : BusinessModelBase  
	{  
		public Int64? QRLoginTransactionId { get; set; }  
		public string TransactionToken { get; set; }  
		public Int64? UserInfoId { get; set; }  
		public string DeviceKey { get; set; }  
		public string DeviceLocalKey { get; set; }  
		public DateTime CreationDate { get; set; }  
		public DateTime ExpireDate { get; set; }  
		public bool IsConfirmed { get; set; }
        public virtual UserInfoBusinessModel? UserInfo { get; set; }
    }  
}  
