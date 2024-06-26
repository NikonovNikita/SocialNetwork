﻿using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Validators
{
    internal class FriendRequestValidator
    {
        private IUserRepository _userRepository;

        public FriendRequestValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserEntity Validate(FriendRequestData friendRequestData)
        {
            if (string.IsNullOrEmpty(friendRequestData.Recipient_Email))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(friendRequestData.Recipient_Email))
                throw new ArgumentException();

            if (friendRequestData.Recipient_Email == friendRequestData.Sender_Email)
                throw new RequestToYourselfException();

            var findedUserEntity = _userRepository.FindByEmail(friendRequestData.Recipient_Email);

            if (findedUserEntity == null)
                throw new UserNotFoundException();

            return findedUserEntity;
        }
    }
}
