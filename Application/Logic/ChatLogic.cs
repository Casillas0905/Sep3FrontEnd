using Application.LogicInterfaces;
using Domain.Models;
using GrpcDataBaseAcces.GrpcServices;

namespace Application.Logic;

public class ChatLogic : IChatLogic
{
    private ChatGrpcService service= new ChatGrpcService();
    public ChatDomainModel findById(int id)
    {
        return service.findById(id);
    }

    public void saveChat(ChatDomainModel chatDomainModel)
    {
        service.saveChat(chatDomainModel);
    }

    public void deleteChat(int id)
    {
        service.deleteChat(id);
    }

    public Task<IEnumerable<ChatDomainModel>> findByUserId(int id)
    {
        return service.findByUserId(id);
    }
}