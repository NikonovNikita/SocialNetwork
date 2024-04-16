using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    internal class UserInfoView
    {
        public void Show(User user)
        {
            Console.WriteLine("Информация о моем профиле:\n");
            Console.WriteLine($"Идентификатор: {user.Id}");
            Console.WriteLine($"Имя: {user.FirstName}");
            Console.WriteLine($"Фамилия: {user.LastName}");
            Console.WriteLine($"Пароль: {user.Password}");
            Console.WriteLine($"Почтовый адрес: {user.Email}");
            Console.WriteLine($"Ссылка на фото: {user.Photo}");
            Console.WriteLine($"Любимый фильм: {user.FavouriteMovie}");
            Console.WriteLine($"Любимая книга: {user.FavouriteBook}");
        }
    }
}
