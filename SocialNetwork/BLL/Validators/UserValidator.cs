using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Validators;

public class UserValidator
{
    private IUserRepository _userRepository;

    internal UserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void UserValidation(UserRegistrationData userRegistrationData)
    {
        IsNullOrEmpty(userRegistrationData.FirstName);
        IsNullOrEmpty(userRegistrationData.LastName);
        IsNullOrEmpty(userRegistrationData.Password);
        IsPasswordValid(userRegistrationData.Password);
        IsEmailValid(userRegistrationData.Email);
    }

    private void IsNullOrEmpty(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException();
    }

    private void IsPasswordValid(string value)
    {
        if (value.Length < 8)
            throw new ArgumentException();
    }

    private void IsEmailValid(string value)
    {
        if (!new EmailAddressAttribute().IsValid(value))
            throw new ArgumentException();

        if (_userRepository.FindByEmail(value) != null)
            throw new ArgumentException();
    }
}
