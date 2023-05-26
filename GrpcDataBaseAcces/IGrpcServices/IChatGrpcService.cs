using Domain.Models;

namespace GrpcDataBaseAcces.IGrpcServices;

public interface IChatGrpcService
{
    public ChatDomainModel findById(int id);
    public void saveChat(ChatDomainModel chatDomainModel);
    public void deleteChat(int id);
    public Task<IEnumerable<ChatDomainModel>> findByUserId(int id);
}