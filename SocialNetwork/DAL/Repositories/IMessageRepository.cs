using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories;

internal interface IMessageRepository
{
    int Create(MessageEntity messageEntity);
    IEnumerable<MessageEntity> FindBySenderId(int senderId);
    IEnumerable<MessageEntity> FindByRecipientId(int recipientId);
    int DeleteById(int messageId);
}
