using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Nihao.commandsList.userCommands;
using Nihao.commandsList;
using NihaoTyancommands;

namespace Nihao
{
    public static class Commands
    {
        public static async Task HandleCommandsAsync(Message message, TelegramBotClient botClient)
        {
            await Listofcommands.AllCommands(message, botClient);

            if (message == null || message.Type != MessageType.Text)
                return;

            var chatId = message.Chat.Id;
            var command = message.Text.ToLower();

            if (command.StartsWith("/start"))
            {
                await Tolking.Start(message, botClient);
            }
            else if (command.StartsWith("/help"))
            {
                await Tolking.Help(message, botClient);
            }
            else if (command.StartsWith("/anecdote"))
            {
                await Anecdote.Send(message, botClient);
            }
            else if (command.StartsWith("/dedinside"))
            {
                await DedInside.DedInsideStart(message, botClient);
            }
            else if (command.StartsWith("/stf"))
            {
                await SteptoFreedom.SteptoFreedomStart(message, botClient);
            }
        }
    }
}
