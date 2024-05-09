using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views;

internal class RequestsOverviewView
{
    FriendService friendService;

    public RequestsOverviewView(FriendService friendService)
    {
        this.friendService = friendService;
    }

    public void Show(IEnumerable<FriendRequest> friendRequests)
    {
        if(friendRequests.Count() < 1)
        {
            Console.WriteLine("У вас нет входящих заявок!");
            return;
        }

        friendRequests.ToList().ForEach(fr =>
        {
            Console.WriteLine($"{fr.Sender_FirstName} {fr.Sender_LastName} ({fr.Sender_Email}) хочет стать вашим другом");

            while (true)
            {
                Console.WriteLine("\n\tПринять заявку --> 1");
                Console.WriteLine("\tОтклонить заявку --> 2");

                var input = Console.ReadLine();

                if(input == "1")
                {
                    try
                    {
                        friendService.AddFriend(fr);

                        SuccessLog.Show($"Пользователь {fr.Sender_FirstName} {fr.Sender_LastName} теперь ваш друг!");

                        break;
                    }
                    catch(Exception ex)
                    {
                        AlertLog.Show($"Возникла непредвиденная ошибка!\n{ex.Message}\n{ex.StackTrace}");

                        break;
                    }
                }

                if(input == "2")
                {
                    try
                    {
                        friendService.RejectFriendRequest(fr);

                        SuccessLog.Show("Заявка успешно отклонена!");

                        break;
                    }
                    catch(Exception ex)
                    {
                        AlertLog.Show($"Возникла непредвиденная ошибка!\n{ex.Message}\n{ex.StackTrace}");

                        break;
                    }
                }
            }
        });
    }
}