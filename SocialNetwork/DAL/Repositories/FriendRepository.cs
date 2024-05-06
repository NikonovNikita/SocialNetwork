using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories;

internal class FriendRepository : BaseRepository, IFriendRepository
{
    public int Create(FriendEntity friendEntity)
    {
        return Execute(@"insert into friends (user_id, friend_id)
                                values (:user_id, :friend_id)", friendEntity);
    }

    public int Delete(int id)
    {
        return Execute(@"delete from friends where id = :id_p", new { id_p = id });
    }

    public IEnumerable<FriendEntity> FindAllByUserId(int userId)
    {
        return Query<FriendEntity>(@"select * from friends where user_id = :user_id or friend_id = :user_id",
            new {user_id = userId});
    }

    public FriendEntity FindFriendEntityByIds(int firstId, int secondId)
    {
        return QueryFirstOrDefault<FriendEntity>(@"select * from friends where (user_id = :firstId and friend_id = :secondId)
                                    or (user_id = :secondId and friendId = :firstId)", new { firstId, secondId });
    }
}
