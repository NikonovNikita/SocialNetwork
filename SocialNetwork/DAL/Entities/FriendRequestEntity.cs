using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Entities;

public class FriendRequestEntity
{
    public int id { get; set; }
    public int sender_id { get; set; }
    public int recipient_id { get; set; }
}
