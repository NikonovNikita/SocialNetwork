using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Validators;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services;

public class FriendService
{
    IFriendRepository friendRepository;
    IFriendRequestRepository friendRequestRepository;
    IUserRepository userRepository;
    FriendRequestValidator friendRequestValidator;
    internal FriendService(IFriendRepository friendRepository, IFriendRequestRepository friendRequestRepository,
        IUserRepository userRepository)
    {
        this.friendRepository = friendRepository;
        this.friendRequestRepository = friendRequestRepository;
        this.userRepository = userRepository;
        friendRequestValidator = new FriendRequestValidator(userRepository, friendRepository, friendRequestRepository);
    }
    public IEnumerable<Friend> GetFriends(int userId)
    {
        var friends = new List<Friend>();

        friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
        {
            int friendId = (userId != f.user_id) ? f.user_id : f.friend_id;

            var friend = userRepository.FindById(friendId);

            friends.Add(new Friend(friend.firstname, friend.lastname, friend.email, friend.photo, friend.favourite_movie,
                friend.favourite_book));
        });

        return friends;
    }

    public void SendFriendRequest(FriendRequestData friendRequestData)
    {
        var recipientEntity = friendRequestValidator.Validate(friendRequestData);

        var friendRequestEntity = new FriendRequestEntity
        {
            sender_id = friendRequestData.Sender_Id,
            recipient_id = recipientEntity.id
        };

        if (friendRequestRepository.Create(friendRequestEntity) == 0)
            throw new Exception();
    }

    public void AddFriend(FriendRequestEntity friendRequestEntity)
    {
        var friendEntity = new FriendEntity { user_id = friendRequestEntity.recipient_id, friend_id = friendRequestEntity.sender_id };

        if(friendRepository.Create(friendEntity) == 0)
            throw new Exception();
    }
}
