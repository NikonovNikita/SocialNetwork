using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    internal class UserMenuView
    {
        UserService userService;
        MessageService messageService;
        FriendService friendService;

        public UserMenuView(UserService userService, MessageService messageService, FriendService friendService)
        {
            this.userService = userService;
            this.messageService = messageService;
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine($"\nВходящие сообщения: {(user.IncomingMessages = messageService.GetIncomingMessages(user.Id)).Count()}");
                Console.WriteLine($"Исходящие сообщения: {(user.OutcomingMessages = messageService.GetOutcomingMessages(user.Id)).Count()}");
                Console.WriteLine($"Входящие заявки в друзья: {(user.IncomingFriendRequests = friendService.GetIncomingRequests(user.Id)).Count()}");
                Console.WriteLine("Посмотреть заявки --> r");
                Console.WriteLine();
                Console.WriteLine("Информация о профиле --> 1");
                Console.WriteLine("Редактировать профиль --> 2");
                Console.WriteLine("Мои друзья --> 3");
                Console.WriteLine("Отправить заявку в друзья --> add");
                Console.WriteLine("Написать сообщение --> 4");
                Console.WriteLine("Входящие сообщения --> 5");
                Console.WriteLine("Исходящие сообщения --> 6");
                Console.WriteLine("Выйти из профиля --> q");

                string input = Console.ReadLine();

                if (input == "q")
                    break;

                switch(input)
                {
                    case "1":
                        Program.userInfoView.Show(user);
                        break;
                    case "2":
                        Program.userDataUpdateView.Show(user);
                        break;
                    case "3":
                        Program.userFriendsView.Show(friendService.GetFriends(user.Id));
                        break;
                    case "r":
                        Program.requestsOverviewView.Show(user.IncomingFriendRequests);
                        break;
                    case "add":
                        Program.requestSendingView.Show(user);
                        break;
                    case "4":
                        Program.messageSendingView.Show(user);
                        break;
                    case "5":
                        Program.userIncomingMessagesView.Show(user.IncomingMessages);
                        break;
                    case "6":
                        Program.userOutcomingMessagesView.Show(user.OutcomingMessages);
                        break;

                }
            }
        }
    }
}
