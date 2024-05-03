using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories;

internal interface IFriendRequestRepository
{
    int Create(FriendRequestEntity friendRequestEntity);
    int Delete(int friendRequestEntityId);
    IEnumerable<FriendRequestEntity> GetAllRequests(int recipient_id);
}
