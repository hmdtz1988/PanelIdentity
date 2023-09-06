using Core;

namespace BusinessModel
{  
	public class CountryBusinessModel : BusinessModelBase  
	{
        public int? CountryId { get; set; }

        public string Title { get; set; } = null!;

        public int LanguageId { get; set; }

        public int CurrencyId { get; set; }

        public string? PhoneCode { get; set; }

        public string? FlagUrl { get; set; }
        public string? CountryCode { get; set; }

        public virtual CurrencyBusinessModel? Currency { get; set; } = null!;

        public virtual LanguageBusinessModel? Language { get; set; } = null!;
    }  
}  
