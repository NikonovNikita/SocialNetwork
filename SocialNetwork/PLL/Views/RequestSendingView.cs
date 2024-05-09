using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    internal class RequestSendingView
    {
        FriendService friendService;
        public RequestSendingView(FriendService friendService)
        {
            this.friendService = friendService;
        }
        public void Show(User user)
        {
            var friendRequestData = new FriendRequestData();

            Console.Write("Введите почтовый адрес пользователя: ");
            friendRequestData.Recipient_Email = Console.ReadLine();

            friendRequestData.Sender_Email = user.Email;
            friendRequestData.Sender_Id = user.Id;

            try
            {
                friendService.SendFriendRequest(friendRequestData);

                SuccessLog.Show("Заявка успешно отправлена!");
            }
            catch (ArgumentNullException)
            {
                AlertLog.Show("Введите непустое значение!");
            }
            catch (ArgumentException)
            {
                AlertLog.Show("Введите корректное значение!");
            }
            catch (RequestToYourselfException)
            {
                AlertLog.Show("Заявка не может быть отправлена самому себе!");
            }
            catch (UserNotFoundException)
            {
                AlertLog.Show("Пользователь не найден!");
            }
            catch (AlreadyFriendException)
            {
                AlertLog.Show("Этот пользователь уже ваш друг!");
            }
            catch (RequestDuplicateException)
            {
                AlertLog.Show("Дубликат заявки! Вы или выбранный пользователь уже создали запрос.");
            }
            catch(Exception ex)
            {
                AlertLog.Show($"Возникла непредвиденная ошибка! {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
