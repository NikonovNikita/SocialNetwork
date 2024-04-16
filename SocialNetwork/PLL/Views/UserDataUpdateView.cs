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
    internal class UserDataUpdateView
    {
        UserService userService;

        public UserDataUpdateView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            Console.Write("Изменение имени: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Изменение фамилии: ");
            user.LastName = Console.ReadLine();

            Console.Write("Изменение ссылки на фото: ");
            user.Photo = Console.ReadLine();

            Console.Write("Изменение любимого фильма: ");
            user.FavouriteMovie = Console.ReadLine();

            Console.Write("Изменение любимой книги: ");
            user.FavouriteBook = Console.ReadLine();

            userService.Update(user);

            SuccessLog.Show("Ваш профиль успешно обновлен!");
        }
    }
}
