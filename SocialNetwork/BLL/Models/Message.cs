using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models;

public class Message
{
    public int Id { get; }
    public string Content { get; }
    public string SenderEmail { get; }
    public string RecipientEmail { get; }
    public string SenderName { get; }
    public string RecipientName { get; }

    public Message(int id, string content, string senderEmail, string recipientEmail, string senderName, string recipientName)
    {
        Id = id;
        Content = content;
        SenderEmail = senderEmail;
        RecipientEmail = recipientEmail;
        SenderName = senderName;
        RecipientName = recipientName;
    }
}
