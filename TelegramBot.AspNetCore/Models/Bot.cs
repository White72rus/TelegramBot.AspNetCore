using System.Threading.Tasks;

using Telegram.Bot;

using TelegramBot.AspNetCore.Infrastructure;

namespace TelegramBot.AspNetCore.Models {
    internal static class Bot {

        private static TelegramBotClient _botClient;

        public static async Task<TelegramBotClient> Get()
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _botClient = new TelegramBotClient(AppSettings.Token);
            //await _botClient.SetWebhookAsync("");

            return _botClient;
        }
    }
}
