using Domain.Models;
using GrpcDataBaseAcces.IGrpcServices;

namespace GrpcDataBaseAcces.GrpcServices;

public class MessageGrpcService : IMessageGrpcService
{
    
    public MessageDomainModel findById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<MessageDomainModel> findAllMessagesForAChat(int id)
    {
        throw new NotImplementedException();
    }

    public void saveMessage(MessageDomainModel messageDomainModel)
    {
        throw new NotImplementedException();
    }

    public void deleteMessage(int id)
    {
        throw new NotImplementedException();
    }
}