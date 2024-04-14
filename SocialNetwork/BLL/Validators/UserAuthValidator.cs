using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
namespace SocialNetwork.BLL.Validators;

public class UserAuthValidator
{
    private IUserRepository _userRepository;
    internal UserAuthValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserEntity AuthValidation(UserAuthenticationData userAuthenticationData)
    {
        var findUserEntity = _userRepository.FindByEmail(userAuthenticationData.Email);

        if (findUserEntity == null)
            throw new UserNotFoundException();

        if (findUserEntity.password != userAuthenticationData.Password)
            throw new WrongPasswordException();

        return findUserEntity;
    }
}
