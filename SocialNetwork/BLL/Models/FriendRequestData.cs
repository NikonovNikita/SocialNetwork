using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models;

public class FriendRequestData
{
    public int Sender_Id { get; set; }
    public string Recipient_Email { get; set; }
    public string Sender_Email { get; set; }
}
