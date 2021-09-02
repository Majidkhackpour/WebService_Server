using System;
using System.Net;
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
        public static WebTelegramMessage GetBackUpLog_bot()
        {
            return new WebTelegramMessage()
            {
                ApiKey = "1924570658:AAG731AopxGpEr7GbchHhSd3TDSdUtGqPxk",
                ChatID = "@AradBackUp",
                ContactType = EnTelegramType.Channel
            };
        }
        public static WebTelegramMessage GetReporter_bot()
        {
            return new WebTelegramMessage()
            {
                ApiKey = "1980977682:AAFMqZCdd1Ov_HvPRo04itE5dy-jRPp5UpY",
                ChatID = "@AradReporter",
                ContactType = EnTelegramType.Channel
            };
        }
        public static WebTelegramMessage GetRealState_bot()
        {
            return new WebTelegramMessage()
            {
                ApiKey = "1938467902:AAGuNKETK__xYRW5fO7zsCO8Df8If91CeLg",
                ChatID = "@Arad_Real_State",
                ContactType = EnTelegramType.Channel
            };
        }
        public static WebTelegramMessage GetTicket_bot()
        {
            return new WebTelegramMessage()
            {
                ApiKey = "1975038302:AAH_yXaVPvq6cHnVgz4cAloFnFqgMuQA0ks",
                ChatID = "@AradTicket",
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

                //var uri = $"https://api.telegram.org/bot{ApiKey}/sendMessage?chat_id={ChatID}&text={message}";
                //using (var client = new WebClient())
                //{
                //    dynamic s = client.DownloadString(uri);
                //}
            }
            catch (HttpRequestException) { }
            catch (Telegram.Bot.Exceptions.BadRequestException) { }
            catch (Telegram.Bot.Exceptions.ApiRequestException) { }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("Unable to connect to the remote server"))
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
