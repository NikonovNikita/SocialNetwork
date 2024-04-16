using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Validators;

public class MessageValidator
{
    private IUserRepository _userRepository;
    internal MessageValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserEntity Validation(MessageSendingData messageSendingData)
    {
        if (string.IsNullOrEmpty(messageSendingData.Content))
            throw new ArgumentNullException();

        if(messageSendingData.Content.Length > 1000)
            throw new ArgumentException();

        if (!new EmailAddressAttribute().IsValid(messageSendingData.RecipientEmail))
            throw new ArgumentException();

        var findedUserEntity = _userRepository.FindByEmail(messageSendingData.RecipientEmail);

        if (findedUserEntity == null)
            throw new UserNotFoundException();

        return findedUserEntity;
    }
}
