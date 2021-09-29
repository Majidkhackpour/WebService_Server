using System;
using System.Net.Http;
using System.Threading.Tasks;
using Services;
using Services.Interfaces;
using Telegram.Bot;

namespace EntityCache.ViewModels
{
    public class WebWhatsappBuilding : IWhatsappBuilding
    {
        public string Number { get; set; }
        public string ApiCode { get; set; }
        public string Message { get; set; }

        public async Task SendAsync()
        {
            try
            {
                var url = $"https://api.callmebot.com/whatsapp.php?phone={Number}&text={Message}&apikey={ApiCode}";

                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;
                }
            }
            catch (HttpRequestException) { }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
