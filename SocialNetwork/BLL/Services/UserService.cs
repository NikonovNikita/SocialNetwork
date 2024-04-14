using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Validators;

namespace SocialNetwork.BLL.Services;

public class UserService
{
    IUserRepository userRepository;
    UserValidator userValidator;
    UserAuthValidator userAuthValidator;

    internal UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        userValidator = new UserValidator(userRepository);
        userAuthValidator = new UserAuthValidator(userRepository);
    }

    public void Register(UserRegistrationData userRegistrationData)
    {
        userValidator.UserValidation(userRegistrationData);

        var userEntity = new UserEntity()
        {
            firstname = userRegistrationData.FirstName,
            lastname = userRegistrationData.LastName,
            password = userRegistrationData.Password,
            email = userRegistrationData.Email,
        };

        if (userRepository.Create(userEntity) == 0)
            throw new Exception("Не удалось создать нового пользователя :(");
    }

    public User Authenticate(UserAuthenticationData userAuthenticationData)
    {
        var findedUserEntity = userAuthValidator.AuthValidation(userAuthenticationData);

        return ConstructUserModel(findedUserEntity);
    }

    public void Update(User user)
    {
        var updatableUserEntity = new UserEntity()
        {
            id = user.Id,
            firstname = user.FirstName,
            lastname = user.LastName,
            password = user.Password,
            email = user.Email,
            photo = user.Photo,
            favourite_movie = user.FavouriteMovie,
            favourite_book = user.FavouriteBook
        };

        if(userRepository.Update(updatableUserEntity) == 0)
            throw new Exception("Не удалось обновить :(");
    }

    private User ConstructUserModel(UserEntity userEntity)
    {
        return new User(userEntity.id, userEntity.firstname, userEntity.lastname, userEntity.password, userEntity.email,
            userEntity.photo, userEntity.favourite_movie, userEntity.favourite_book);
    }
}
