using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views;

internal class MessageSendingView
{
    MessageService messageService;

    public MessageSendingView(MessageService messageService)
    {
        this.messageService = messageService;
    }

    public void Show(User user)
    {
        var messageSendingData = new MessageSendingData();

        Console.Write("Введите почтовый адрес получателя: ");
        messageSendingData.RecipientEmail = Console.ReadLine();

        Console.Write("Введите сообщение (не более 1000 символов): ");
        messageSendingData.Content = Console.ReadLine();

        messageSendingData.SenderId = user.Id;

        try
        {
            messageService.SendMessage(messageSendingData);

            SuccessLog.Show("Сообщение успешно отправлено!");
        }
        catch (ArgumentNullException)
        {
            AlertLog.Show("Введите корректное непустое значение!");
        }
        catch (ArgumentException)
        {
            AlertLog.Show("Введите корректное значение!");
        }
        catch (UserNotFoundException)
        {
            AlertLog.Show("Пользователь не найден!");
        }
        catch(Exception ex)
        {
            AlertLog.Show($"Неизвестная ошибка!\n{ex.Message}\n{ex.StackTrace}");
        }
    }
}
