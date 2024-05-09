using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    internal class FriendRequestRepository : BaseRepository, IFriendRequestRepository
    {
        public int Create(FriendRequestEntity friendRequestEntity)
        {
            return Execute(@"insert into friend_requests(sender_id, recipient_id)
                                        values(:sender_id, :recipient_id)", friendRequestEntity);
        }

        public int Delete(int friendRequestEntityId)
        {
            return Execute("delete from friend_requests where id = :id", new {id = friendRequestEntityId});
        }

        public FriendRequestEntity FindById(int id)
        {
            return QueryFirstOrDefault<FriendRequestEntity>(@"select * from friend_requests where id = :id", new { id });
        }

        public FriendRequestEntity FindFriendRequestEntityByIds(int senderId, int recipientId)
        {
            return QueryFirstOrDefault<FriendRequestEntity>(@"select * from friend_requests where sender_id = :senderId
                                                            and recipient_id = :recipientId", new {senderId, recipientId});
        }

        public IEnumerable<FriendRequestEntity> GetAllRequests(int recipient_id)
        {
            return Query<FriendRequestEntity>("select * from friend_requests where recipient_id = :recipient_id",
                new { recipient_id });
        }
    }
}
