using Domain.Models;

namespace Application.LogicInterfaces;

public interface IChatLogic
{
    public ChatDomainModel findById(int id);
    public void saveChat(ChatDomainModel chatDomainModel);
    public void deleteChat(int id);
    public Task<IEnumerable<ChatDomainModel>> findByUserId(int id);
}