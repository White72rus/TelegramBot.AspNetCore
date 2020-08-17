using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Telegram.Bot;

using TelegramBot.AspNetCore.Models;
using TelegramBot.AspNetCore.Models.Commands;

namespace TelegramBot.AspNetCore.Services {
    public class BotService : IHostedService {

        private CommandsList commands = new CommandsList();

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            commands.Add(new HelloCommand());
            commands.Add(new DateCommand());
            commands.Add(new HateCommand());
            commands.Add(new StartCommand());
            commands.Add(new HelpCommand());
            commands.Add(new NoCommand());

            TelegramBotClient bot = await Bot.Get();
            if (bot != null) 
                Console.WriteLine("Bot started...");
            else 
                Console.WriteLine("Bot started error...");

            bot.OnMessage += OnMessageEvent;

            bot?.StartReceiving();

            if (bot.IsReceiving) 
                Console.WriteLine("Bot started receiving...");

            //var u = await bot.GetUpdatesAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private void OnMessageEvent(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            string msg = $"FirstName: {e.Message.Chat.FirstName} Chat Id: {e.Message.Chat.Id} Message: {e.Message.Text}\n" +
                $"From: {e.Message.From.FirstName} id: {e.Message.From.Id} UserName: @{e.Message.From.Username}";
            Console.WriteLine(msg);

            foreach (var command in commands)
            {
                if (e.Message.Text != null)
                {
                    if (command.Contains(e.Message.Text) && !string.IsNullOrWhiteSpace(command.Name))
                    {
                        command.Execute(e.Message, sender as TelegramBotClient);
                    }
                    if (e.Message.From.Username == "Mishka911")
                    {
                        //command.Execute(e.Message, sender as TelegramBotClient);
                    }
                }
            }
        }
    }
}
