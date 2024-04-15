using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    static UserService userService = new UserService(new UserRepository());
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в социальную сеть!\n");

        while (true)
        {
            Console.WriteLine("Войти в профиль --> 1");
            Console.WriteLine("Зарегистрироваться --> 2");

            switch(Console.ReadLine())
            {
                case "1":
                    {
                        var authenticationData = new UserAuthenticationData();
                        
                        Console.Write("Введите почтовый адрес: ");
                        authenticationData.Email = Console.ReadLine();

                        Console.Write("Введите пароль: ");
                        authenticationData.Password = Console.ReadLine();

                        try
                        {
                            User user = userService.Authenticate(authenticationData);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Вы успешно вошли в социальную сеть! С возвращением, {user.FirstName} {user.LastName}");
                            Console.ForegroundColor = ConsoleColor.White;

                            while (true)
                            {
                                Console.WriteLine("\nПосмотреть информацию о моем профиле --> 1");
                                Console.WriteLine("Редактировать мой профиль --> 2");
                                Console.WriteLine("Добавить в друзья --> 3");
                                Console.WriteLine("Написать сообщение --> 4");
                                Console.WriteLine("Проверить сообщения --> 5");
                                Console.WriteLine("Выйти из профиля --> q");

                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Информация о моем профиле:");
                                            Console.WriteLine($"Мой идентификатор: {user.Id}");
                                            Console.WriteLine($"Меня зовут: {user.FirstName}");
                                            Console.WriteLine($"Моя фамилия: {user.LastName}");
                                            Console.WriteLine($"Мой пароль: {user.Password}");
                                            Console.WriteLine($"Мой почтовый адрес: {user.Email}");
                                            Console.WriteLine($"Ссылка на мое фото: {user.Photo}");
                                            Console.WriteLine($"Мой любимый фильм: {user.FavouriteMovie}");
                                            Console.WriteLine($"Моя любимая книга: {user.FavouriteBook}");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.WriteLine("Давайте изменим информацию вашего профиля:");

                                            Console.Write("Меня зовут: ");
                                            user.FirstName = Console.ReadLine();

                                            Console.Write("Моя фамилия: ");
                                            user.LastName = Console.ReadLine();

                                            Console.Write("Ссылка на мое фото: ");
                                            user.Photo = Console.ReadLine();

                                            Console.Write("Мой любимый фильм: ");
                                            user.FavouriteMovie = Console.ReadLine();

                                            Console.Write("Моя любимая книга: ");
                                            user.FavouriteBook = Console.ReadLine();

                                            userService.Update(user);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Ваш профиль успешно обновлен!");
                                            Console.ForegroundColor = ConsoleColor.White;

                                            break;
                                        }
                                    case "q":
                                        {
                                            throw new ExitFromAccountException();
                                        }
                                }
                            }
                        }
                        catch (UserNotFoundException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Пользователь не найден!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        catch (WrongPasswordException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неверный пароль!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        catch (ExitFromAccountException)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Вы вышли из своего аккаунта!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Для успешного прохождения регистрации необходимо ввести следующие данные:");
                        Console.Write("Имя пользователя: ");
                        string firstNameInput = Console.ReadLine();
                        Console.Write("Фамилия пользователя: ");
                        string lastNameInput = Console.ReadLine();
                        Console.Write("Пароль: ");
                        string passwordInput = Console.ReadLine();
                        Console.Write("Почтовый адрес: ");
                        string emailInput = Console.ReadLine();

                        try
                        {
                            userService.Register(new UserRegistrationData
                            { FirstName = firstNameInput, LastName = lastNameInput, Password = passwordInput, Email = emailInput });
                            
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Регистрация прошла успешно!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        catch (ArgumentNullException ane)
                        {
                            Console.WriteLine($"Ошибка при регистрации! Введите корректные значения!\n{ane.Message}");
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine($"Ошибка при регистрации! Введите корректные значения!\n{ae.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка при регистрации! {ex.Message}\n{ex.StackTrace}");
                        }

                        break;
                    }
            }
        }
    }
}