using System;
using System.Net.Http;
using System.Threading.Tasks;
using Services;
using Telegram.Bot;

namespace EntityCache.ViewModels
{
    public class WebTelegramMessage
    {
        public string ApiKey { get; set; }
        public string ChatID { get; set; }
        public EnTelegramType ContactType { get; set; }


        public static WebTelegramMessage GetErrorLog_bot()
        {
            return new WebTelegramMessage()
            {
                ApiKey = "1498051495:AAEINIXXlleb0DFHl9C8IOxuHKWH58ksDJg",
                ChatID = "@Error_Handler_Log",
                ContactType = EnTelegramType.Channel
            };
        }
        public void Send(string message) => Task.Run(() => SendAsync(message));
        public async Task SendAsync(string message)
        {
            try
            {
                var bot = new TelegramBotClient(ApiKey);
                await bot.SendTextMessageAsync(ChatID, message);
            }
            catch (HttpRequestException) { }
            catch (Telegram.Bot.Exceptions.BadRequestException)
            {
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException)
            {
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
