using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IMessagesService 
{
    public Task<MessageDomainModel> findById(int id);
    public Task<IEnumerable<MessageDomainModel>> findAllMessagesForAChat(int id);
    public Task saveMessage(MessageDomainModel messageDomainModel);
    public void deleteMessage(int id);
}