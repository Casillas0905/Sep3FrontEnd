using Domain.Models;

namespace GrpcDataBaseAcces.IGrpcServices;

public interface IMessageGrpcService
{
    public MessageDomainModel findById(int id);
    public Task<IEnumerable<MessageDomainModel>> findAllMessagesForAChat(int id);
    public void saveMessage(MessageDomainModel messageDomainModel);
    public void deleteMessage(int id);
}