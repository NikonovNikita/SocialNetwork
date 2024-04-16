namespace SocialNetwork.BLL.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Photo {  get; set; }
    public string FavouriteMovie { get; set; }
    public string FavouriteBook { get; set; }

    public IEnumerable<Message> IncomingMessages { get; set; }
    public IEnumerable<Message> OutcomingMessages { get; set; }

    public User(int id, string firstName, string lastName, string password, string email, 
        string photo, 
        string favouriteMovie, 
        string favouriteBook)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        Photo = photo;
        FavouriteMovie = favouriteMovie;
        FavouriteBook = favouriteBook;
    }
}
