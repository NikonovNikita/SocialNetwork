using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services;

public class UserService
{
    IUserRepository userRepository;
    public UserService()
    {
        userRepository = new UserRepository();
    }

    public void Register(UserRegistrationData userRegistrationData)
    {
        if (string.IsNullOrEmpty(userRegistrationData.FirstName))
            throw new ArgumentNullException();

        if(string.IsNullOrEmpty(userRegistrationData.LastName))
            throw new ArgumentNullException();

        if(string.IsNullOrEmpty(userRegistrationData.Password))
            throw new ArgumentNullException();

        if(userRegistrationData.Password.Length < 8)
            throw new ArgumentException();

        if(!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
            throw new ArgumentException();

        if(userRepository.FindByEmail(userRegistrationData.Email) != null)
            throw new ArgumentException();

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
        var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
        
        if(findUserEntity == null)
            throw new UserNotFoundException();
        
        if (findUserEntity.password != userAuthenticationData.Password)
            throw new WrongPasswordException();

        return ConstructUserModel(findUserEntity);
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
