using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;
using System;
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
    }
}
