using Kavenegar;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExternalServices
{
    public class SendSMSService
    {
        public async Task<KavehnegarVerifySmsEntry> VerifySMS(string receptor, string token, string token2, string templateName = "futurewaves-login")
        {
            string ss = string.Empty;
            string apiKey = "2F7834493466683442497454587838674649315562414F6D3779376F6236645934566E4E6D706D344348633D";
            var url = @"https://api.kavenegar.com/v1/" + apiKey + @"/verify/lookup.json?receptor=" + receptor + @"&token=" + token + @"&token3=ERP" + @"&token2=" + token2 + @"&template=" + templateName;

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<KN_VerifySmsModel>(responseString);
            var smsData = result.entries.FirstOrDefault();
            return smsData;
        }

    }
}
