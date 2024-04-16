using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views;

internal class UserIncomingMessagesView
{
    public void Show(IEnumerable<Message> incomingMessages)
    {
        Console.WriteLine("Входящие сообщения:\n");

        if(incomingMessages.Count() == 0)
        {
            Console.WriteLine("Входящих сообщений нет");
            return;
        }

        incomingMessages.ToList().ForEach(message =>
        {
            Console.WriteLine($"От кого: {message.SenderName} ({message.SenderEmail})\n" +
                $"Текст сообщения: {message.Content}\n");
        });
    }
}
