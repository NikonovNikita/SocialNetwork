using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models;

public class FriendRequest
{
    public int Id { get; }
    public string Sender_Email { get; }
    public string Sender_FirstName { get; }
    public string Sender_LastName { get; }

    internal FriendRequest(int id, string sender_email, string sender_firstname, string sender_lastname)
    {
        Id = id;
        Sender_Email = sender_email;
        Sender_FirstName = sender_firstname;
        Sender_LastName = sender_lastname;
    }
}
