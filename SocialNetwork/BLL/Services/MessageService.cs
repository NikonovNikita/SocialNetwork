using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Validators;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.Reflection.Metadata;

namespace SocialNetwork.BLL.Services;

public class MessageService
{
    private IMessageRepository _messageRepository;
    private IUserRepository _userRepository;
    MessageValidator messageValidator;

    internal MessageService(IMessageRepository messageRepository, IUserRepository userRepository)
    {
        _messageRepository = messageRepository;
        _userRepository = userRepository;
        messageValidator = new MessageValidator(userRepository);
    }

    public IEnumerable<Message> GetIncomingMessages(int recipientId)
    {
        var messages = new List<Message>();

        _messageRepository.FindByRecipientId(recipientId).ToList().ForEach(m =>
        {
            var sender = _userRepository.FindById(m.sender_id);
            var recipient = _userRepository.FindById(m.recipient_id);

            messages.Add(new Message(m.id, m.content, sender.email, recipient.email, sender.firstname, recipient.firstname));
        });

        return messages;
    }

    public IEnumerable<Message> GetOutcomingMessages(int senderId)
    {
        var messages = new List<Message>();

        _messageRepository.FindBySenderId(senderId).ToList().ForEach(m =>
        {
            var sender = _userRepository.FindById(m.sender_id);
            var recipient = _userRepository.FindById(m.recipient_id);

            messages.Add(new Message(m.id, m.content, sender.email, recipient.email, sender.firstname, recipient.firstname));
        });

        return messages;
    }

    public void SendMessage(MessageSendingData messageSendingData)
    {
        var findedUserEntity = messageValidator.Validation(messageSendingData);

        var messageEntity = new MessageEntity
        {
            content = messageSendingData.Content,
            sender_id = messageSendingData.SenderId,
            recipient_id = findedUserEntity.id
        };

        if (_messageRepository.Create(messageEntity) == 0)
            throw new Exception();
    }
}