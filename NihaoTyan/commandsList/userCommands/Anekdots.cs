using System;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Nihao.commandsList.userCommands
{

    public static class Anecdote
    {
        public static async Task Send(Message message, TelegramBotClient botClient)
        {
            Random _random = new Random();
            var anecdotes = System.IO.File.ReadAllText("anekdots.txt").Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var randomAnecdote = anecdotes[_random.Next(anecdotes.Length)];

            await botClient.SendTextMessageAsync(message.Chat.Id, randomAnecdote);
        }
    }
}