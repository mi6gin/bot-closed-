using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace NihaoTyancommands
{
    public class Listofcommands
    {
        public static async Task AllCommands(Message message, TelegramBotClient botClient)
        {
            try
            {
                // Регистрация команд в Telegram
                var commands = new List<BotCommand>
            {
                new BotCommand { Command = "start", Description = "Поздороватся с Нихао" },
                new BotCommand { Command = "help", Description = "Позвать Нихао" },
                new BotCommand { Command = "dedinside", Description = "Позвать Нихао" },
                new BotCommand { Command = "stf", Description = "Прогулка к независимости" },
                new BotCommand { Command = "anecdote", Description = "Расскажи анекдот про Штирлица" }
            };

                await botClient.SetMyCommandsAsync(commands);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
