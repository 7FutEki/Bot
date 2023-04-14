using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.GettingUpdates;

internal class Program
{
    static public string token = "6194620142:AAGC06lR2LcpU9QQrhHTKWvAk0CqT_ZP11k";
    static public BotClient api = new BotClient(token);
    private static void Main(string[] args)
    {
        var updates = api.GetUpdates(); 

        while (true)
        {
            if(updates.Any()) 
            {
                foreach(var item in updates)
                {
                    if (item.Message.Text.ToLower() == "/start")
                    {
                        api.SendMessage(item.Message.Chat.Id, "Я бот помощник");
                    }
                    else if (item.Message.Text.ToLower() == "/help")
                    {
                        api.SendMessage(item.Message.Chat.Id, "Помогаю");
                    }
                    else if (item.Message.Text.ToLower() == "/bot")
                    {
                        api.SendMessage(item.Message.Chat.Id, "Я никчемный");
                    }
                }
                var offset = updates.Last().UpdateId + 1;
                updates= api.GetUpdates(offset);
            }
            else
            {
                updates = api.GetUpdates();
            }
        }
    }
}