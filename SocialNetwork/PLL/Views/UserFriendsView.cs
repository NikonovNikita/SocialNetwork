﻿using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    internal class UserFriendsView
    {
        public void Show(IEnumerable<Friend> friends)
        {
            if (friends.Count() < 1)
            {
                Console.WriteLine("\nВы еще ни с кем не подружились!\nПроверьте входящие запросы или отправьте свой!\n");
                return;
            }

            Console.WriteLine("Мои друзья:");
            friends.ToList().ForEach(f =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{f.FirstName} {f.LastName} ({f.Email})");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ссылка на фото: {f.Photo}");
                Console.WriteLine($"Любимый фильм: {f.Favourite_Movie}"); //Сделать проверку на null как-то
                Console.WriteLine($"Любимая книга: {f.Favourite_Book}"); //Сделать проверку на null как-то
            });
        }
    }
}
