using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services;

public class MessageService
{
    IMessageRepository messageRepository;

    internal MessageService(IMessageRepository messageRepository)
    {
        this.messageRepository = messageRepository;
    }

    public void SendMessage(string userMessage)
    {

    }

    public void ReviewMessages()
    {

    }
}
