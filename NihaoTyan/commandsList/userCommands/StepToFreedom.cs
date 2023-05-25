using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Nihao.commandsList.userCommands
{
    class SteptoFreedom
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient(Config.Token);
        private static long _userId;
        private static long _chatId; // Переменная для хранения идентификатора чата отправителя команды

        public static int xn;
        public static string sonicX;

        public static async Task SteptoFreedomStart(Message message, TelegramBotClient botClient)
        {
            _chatId = message.Chat.Id; // Сохраняем идентификатор чата отправителя команды
            _userId = message.From.Id;
            var photoUrl = "https://sun9-1.userapi.com/impg/dnvKms_lz49AsprMp7u2WORn8iBtyAShpRcQKg/WincNLcilWA.jpg?size=1170x1170&quality=95&sign=c5ebdc06d298cdd8d3812611b1f8ae56&type=album";

            var keyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Запуск", "callback_data_1"),
                    InlineKeyboardButton.WithCallbackData("Отмена", "callback_data_2")
                }
            });

            var msgTodelete = await botClient.SendPhotoAsync(_chatId, photoUrl,
                "Привет товарищ mi6gun, ты запустил особый режим\r\nРежим ПРОГУЛКИ подразумевает концентрацию и усидчевость\r\nКак будешь готов дай мне знать",
                replyMarkup: keyboard);
        }

        public async Task HandleCallbackQuery(CallbackQuery callbackQuery, Message message, TelegramBotClient botClient)
        {
            var chatId = callbackQuery.Message.Chat.Id;
            var messageId = callbackQuery.Message.MessageId;

            if (callbackQuery.Data == "callback_data_1")
            {
                await botClient.DeleteMessageAsync(chatId, messageId);
                await SteptoFreedom.STFhelper(message, botClient);
            }
            else if (callbackQuery.Data == "callback_data_2")
            {
                await botClient.SendTextMessageAsync(chatId, "Пока");
            }

            // Ответить на callback-запрос, чтобы убрать уведомление о нажатии кнопки
            await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);
        }

        public static async Task STFhelper(Message message, TelegramBotClient botClient)
        {
            if (xn == 30)
            {
                xn = 15;
                await SteptoFreedom.STF(message, botClient);
            }
            else if(xn == 15)
            {
                await SteptoFreedom.SteptoFreedomStart(message, botClient);
            }
            else
            {
                xn = 1;
            }
            await SteptoFreedom.STF(message, botClient);

        }

        public static async Task STF(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            if (xn == 1)
            {
                sonicX = "Впахивай как стахановец следующие";
                xn = 30;
            }
            else if(xn == 15)
            {
                sonicX = "Отдыхай пролетарий следующие";
            }
            int totalSeconds = xn * 60; // Общее количество секунд (30 минут)
            int remainingSeconds = totalSeconds;

            Message timerMessage = null;

            while (remainingSeconds > 0)
            {
                // Форматируем оставшееся время в формат ММ:СС
                string timeString = $"{sonicX} {remainingSeconds / 60:00}:{remainingSeconds % 60:00}";

                if (timerMessage == null)
                {
                    // Отправляем первое сообщение с таймером
                    timerMessage = await botClient.SendTextMessageAsync(chatId, timeString);
                }
                else
                {
                    await botClient.EditMessageTextAsync(chatId, timerMessage.MessageId, timeString);

                }

                // Ожидаем 1 секунду
                await Task.Delay(1000);
                remainingSeconds--;
            }
            await SteptoFreedom.STFhelper(message, botClient);

        }

    }
}
