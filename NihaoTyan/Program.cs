using Nihao;
using Nihao.commandsList.userCommands;
using System;
using Telegram.Bot;


namespace Nihao
{
    class Program
    {
        private static SteptoFreedom steptoFreedom;
        static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient(Config.Token);


            var me = await botClient.GetMeAsync();
            Console.Title = me.Username;

            botClient.OnMessage += async (sender, messageEventArgs) =>
            {
                var message = messageEventArgs.Message;
                await Commands.HandleCommandsAsync(message, botClient);
            };

            botClient.StartReceiving();
            botClient.OnMessage += DedInside.OnMessage;

            botClient.OnCallbackQuery += async (sender, callbackQueryEventArgs) =>
            {
                steptoFreedom = new SteptoFreedom(); // Создаем экземпляр класса SteptoFreedom
                var callbackQuery = callbackQueryEventArgs.CallbackQuery;
                var message = callbackQuery.Message;
                await steptoFreedom.HandleCallbackQuery(callbackQuery, message, botClient);
            };

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            botClient.StopReceiving();
        }
    }
}
