using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IChatService
{
    public Task<ChatDomainModel> findById(int id);
    public void deleteChat(int id);
    public Task<IEnumerable<ChatDomainModel>> findByUserId(int id);
}