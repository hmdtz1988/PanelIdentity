using Core;

namespace BusinessModel
{  
	public class AccountTypeBusinessModel : BusinessModelBase  
	{  
		public Int64? AccountTypeId { get; set; }  
		public string TitleFa { get; set; }  
		public string TitleEn { get; set; }  
		public string TitleTr { get; set; }  
		public string TitleAr { get; set; }  
		public string TitleDu { get; set; }  
		public string TitleFr { get; set; }
        public virtual ICollection<ProjectAccountTypeBusinessModel>? ProjectAccountTypes { get; set; }

    }
}  
