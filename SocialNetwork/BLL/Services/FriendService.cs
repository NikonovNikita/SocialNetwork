using SocialNetwork.BLL.Exceptions;
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
        friendRequestValidator = new FriendRequestValidator(userRepository);
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

    public IEnumerable<FriendRequest> GetIncomingRequests(int recipientId)
    {
        var incomingRequests = new List<FriendRequest>();

        friendRequestRepository.GetAllRequests(recipientId).ToList().ForEach(r =>
        {
            var sender = userRepository.FindById(r.sender_id);

            incomingRequests.Add(new FriendRequest(r.id, sender.email, sender.firstname, sender.lastname));
        });

        return incomingRequests;
    }

    public void SendFriendRequest(FriendRequestData friendRequestData)
    {
        var recipientEntity = friendRequestValidator.Validate(friendRequestData);

        CheckFriendRequest(friendRequestData, recipientEntity);

        var friendRequestEntity = new FriendRequestEntity
        {
            sender_id = friendRequestData.Sender_Id,
            recipient_id = recipientEntity.id
        };

        if (friendRequestRepository.Create(friendRequestEntity) == 0)
            throw new Exception();
    }

    public void AddFriend(FriendRequest friendRequest)
    {
        var friendRequestEntity = friendRequestRepository.FindById(friendRequest.Id);
        
        var friendEntity = new FriendEntity { user_id = friendRequestEntity.recipient_id, friend_id = friendRequestEntity.sender_id };

        if (friendRequestRepository.Delete(friendRequest.Id) == 0)
            throw new Exception();

        if(friendRepository.Create(friendEntity) == 0)
            throw new Exception();
    }

    public void RejectFriendRequest(FriendRequest friendRequest)
    {
        if(friendRequestRepository.Delete(friendRequest.Id) == 0)
            throw new Exception();
    }

    private void CheckFriendRequest(FriendRequestData friendRequestData, UserEntity recipientEntity)
    {
        //Проверка, существует ли пользователь уже в друзьях
        if (friendRepository.FindFriendEntityByIds(friendRequestData.Sender_Id, recipientEntity.id) != null)
            throw new AlreadyFriendException();

        //Проверка, существует ли уже запрос выбранному пользователю
        if(friendRequestRepository.FindFriendRequestEntityByIds(friendRequestData.Sender_Id, recipientEntity.id) != null)
            throw new RequestDuplicateException();

        //Проверка, не существует ли уже запрос от желаемого пользователя текущему, чтобы не дублировать заявки
        if(friendRequestRepository.FindFriendRequestEntityByIds(recipientEntity.id, friendRequestData.Sender_Id) != null)
            throw new RequestDuplicateException();
    }
}
