using Telegram.Bot;
using Telegram.Bot.Types;

namespace Nihao.commandsList.userCommands
{
    public class Tolking
    {
        public static async Task Start(Message message, TelegramBotClient botClient)
        {
            // Здесь находится код для обработки команды "/start"
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, "Здравствуйте товарищ ✌️, меня зовут Нихао, я ассистент мистера Романова!\r\nЕсли вам что-нибудь понадобится, то просто воспользуйтесь командой /help, и я сразу же прийду к вам на помощь!");
        }

        public static async Task Help(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            var photoUrl = "https://sun9-1.userapi.com/impg/dnvKms_lz49AsprMp7u2WORn8iBtyAShpRcQKg/WincNLcilWA.jpg?size=1170x1170&quality=95&sign=c5ebdc06d298cdd8d3812611b1f8ae56&type=album";
            await botClient.SendPhotoAsync(chatId, photoUrl, "Ну что товарищ, вам нужна моя помощь?\r\nНе волнуйтесь, сейчас я вам всё объясню и расскажу😉\r\nСреди доступных мне функций есть:\r\n\r\n/tiktok-скачать аудио дорожку из видео из тиктока, для скачивания видео(без вобдяного знака) никаких комманд отправлять не нужно, просто отправь ссылку в чат;\r\n\r\n/wiki-поиск на википедии, для просмотра полных статей просто выбери @nihao_tyan_bot и напиши свой запрос\r\n\r\nНу вроде это всё, про /help и /start я рассказывать не стала, потому что вы уже и так знаете, что они делают😅");
        }

    }
}