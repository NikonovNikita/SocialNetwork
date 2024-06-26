﻿using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views;

public class AuthenticationView
{
    UserService userService;

    public AuthenticationView(UserService userService)
    {
        this.userService = userService;
    }

    public void Show()
    {
        var authenticationData = new UserAuthenticationData();

        Console.Write("Введите почтовый адрес: ");
        authenticationData.Email = Console.ReadLine();

        Console.Write("Введите пароль: ");
        authenticationData.Password = Console.ReadLine();

        try
        {
            var user = userService.Authenticate(authenticationData);

            SuccessLog.Show("Вы успешно вошли в социальную сеть!");
            SuccessLog.Show($"С возвращением, {user.FirstName} {user.LastName}");

            Program.userMenuView.Show(user);
        }
        catch (WrongPasswordException)
        {
            AlertLog.Show("Пароль не корректный!");
        }
        catch (UserNotFoundException)
        {
            AlertLog.Show("Пользователь не найден!");
        }
        catch (Exception ex)
        {
            AlertLog.Show($"Неизвестная ошибка!\n{ex.Message}");
        }
    }
}
