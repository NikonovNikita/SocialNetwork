using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views;

public class RegistrationView
{
    UserService userService;

    public RegistrationView(UserService userService)
    {
        this.userService = userService;
    }

    public void Show()
    {
        var userRegistrationData = new UserRegistrationData();

        Console.WriteLine("Для успешного прохождения регистрации введите следующие данные:");

        Console.Write("Имя: ");
        userRegistrationData.FirstName = Console.ReadLine();

        Console.Write("Фамилия: ");
        userRegistrationData.LastName = Console.ReadLine();

        Console.Write("Придумайте пароль: ");
        userRegistrationData.Password = Console.ReadLine();

        Console.Write("Почтовый адрес: ");
        userRegistrationData.Email = Console.ReadLine();

        try
        {
            userService.Register(userRegistrationData);

            SuccessLog.Show("Регистрация прошла успешно! Войдите в систему под своими учетными данными :)");
        }
        catch (ArgumentNullException)
        {
            AlertLog.Show("Введите корректные значения!");
        }
        catch (ArgumentException)
        {
            AlertLog.Show("Введите корректные значения!");
        }
        catch(Exception ex)
        {
            AlertLog.Show($"Произошла неизвестная ошибка при регистрации\n{ex.Message}\n{ex.StackTrace}");
        }
    }
}
