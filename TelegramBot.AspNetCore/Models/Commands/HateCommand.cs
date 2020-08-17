using System;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.AspNetCore.Models.Commands {
    internal class HateCommand : Command {
        public HateCommand()
        {

        }
        public override string Name => "";
        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, "Мишка потная подмышка");
        }
    }
}
