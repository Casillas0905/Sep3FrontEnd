using Application.LogicInterfaces;
using Domain.Models;
using GrpcDataBaseAcces.GrpcServices;

namespace Application.Logic;

public class MessageLogic : IMessageLogic
{
    private MessageGrpcService service = new MessageGrpcService();
    
    public MessageDomainModel findById(int id)
    {
        return service.findById(id);
    }

    public Task<IEnumerable<MessageDomainModel>> findAllMessagesForAChat(int id)
    {
        return service.findAllMessagesForAChat(id);
    }

    public void saveMessage(MessageDomainModel messageDomainModel)
    {
        service.saveMessage(messageDomainModel);
    }

    public void deleteMessage(int id)
    {
        service.deleteMessage(id);
    }
}