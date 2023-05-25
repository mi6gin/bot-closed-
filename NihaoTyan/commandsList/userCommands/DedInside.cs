using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Nihao.commandsList.userCommands
{
    class DedInside
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient(Config.Token);
        private static long _userId;

        private enum FSM
        {
            Start,
            Upominanie
        }

        private static FSM _state;

        private static long _chatId; // Переменная для хранения идентификатора чата отправителя команды

        public static bool isFirstMessage = true;

        public static async Task DedInsideStart(Message message, TelegramBotClient botClient)
        {
            _chatId = message.Chat.Id; // Сохраняем идентификатор чата отправителя команды
            _userId = message.From.Id;
            await Bot.SendTextMessageAsync(_chatId, "Привет! Я могу отправить сообщение с текстом '@Дедушка, сколько времени?' до 25 раз. Начнем?");
            isFirstMessage = true;
            _state = FSM.Upominanie;
        }

        public static async Task Upominanie(Message message)
        {
            if (message.Type == MessageType.Text)
            {
                if (isFirstMessage && message.Text.StartsWith("@"))
                {
                    isFirstMessage = false;
                    for (int i = 0; i < 100; i++)
                    {
                        var sentMessage = await Bot.SendTextMessageAsync(_chatId, message.Text);
                        await Task.Delay(1000);
                        await Bot.DeleteMessageAsync(_chatId, sentMessage.MessageId);
                    }
                    _state = FSM.Start;
                }
                else if (isFirstMessage)
                {
                    isFirstMessage = false;
                    await Bot.SendTextMessageAsync(_chatId, 
                        "Нет-нет-нет, товарищ...\nВы делаете всё не так, надо указывать перед ником \"@\"\nНапример [@githab_parasha]");
                }
            }
        }

        public static async void OnMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message;

            // Пропускаем сообщения, если идентификатор отправителя не совпадает с идентификатором пользователя, отправившего команду
            if (message.From.Id != _userId)
            {
                return;
            }

            switch (_state)
            {
                case FSM.Upominanie:
                    await Upominanie(message);
                    break;
            }
        }

    }
}
