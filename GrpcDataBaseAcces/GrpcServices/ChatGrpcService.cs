using Domain.Models;
using GrpcDataBaseAcces.IGrpcServices;

namespace GrpcDataBaseAcces.GrpcServices;

public class ChatGrpcService : IChatGrpcService
{
    public ChatDomainModel findById(int id)
    {
        throw new NotImplementedException();
    }

    public void saveChat(ChatDomainModel chatDomainModel)
    {
        throw new NotImplementedException();
    }

    public void deleteChat(int id)
    {
        throw new NotImplementedException();
    }

    public ChatDomainModel findByUserId(int id)
    {
        throw new NotImplementedException();
    }
}