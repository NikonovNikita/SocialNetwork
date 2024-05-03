using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models;

public class Friend
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Photo { get; }
    public string Favourite_Movie { get; }
    public string Favourite_Book { get; }

    internal Friend(string firstName, string lastName, string email, string photo, string favourite_Movie, string favourite_Book)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Photo = photo;
        Favourite_Movie = favourite_Movie;
        Favourite_Book = favourite_Book;
    }
}
