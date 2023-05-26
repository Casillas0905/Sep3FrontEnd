using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClasses.Chat;
using GrpcDataBaseAcces.IGrpcServices;

namespace GrpcDataBaseAcces.GrpcServices;

public class ChatGrpcService : IChatGrpcService
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private Chats.ChatsClient client = new Chats.ChatsClient(channel);
    
    public ChatDomainModel findById(int id)
    {
        var req = new lookUpById(){ Id = id };
        var chat= client.findById(req);
        ChatDomainModel newChat = new ChatDomainModel(chat.Id,chat.UserId1, chat.UserId2);
        return newChat;
    }

    public void saveChat(ChatDomainModel chatDomainModel)
    {
        ChatModel chat = new ChatModel()
        {
            Id = chatDomainModel.id,
            UserId2 = chatDomainModel.userId2,
            UserId1 = chatDomainModel.userId1
        };
        client.saveChat(chat);
    }

    public void deleteChat(int id)
    {
        var req = new lookUpById() { Id = id };
        client.deleteChat(req);
    }

    public async Task<IEnumerable<ChatDomainModel>> findByUserId(int id)
    {
        var req = new lookUpByUserId() { UserId = id };
        using var call = client.findByUserId(req);
        List<ChatDomainModel> list = new List<ChatDomainModel>();
        while (await call.ResponseStream.MoveNext())
        {
            var chat = call.ResponseStream.Current;
            ChatDomainModel chatModel = new ChatDomainModel() {
                id = chat.Id,
                userId2 = chat.UserId1,
                userId1 = chat.UserId2 };
            list.Add(chatModel);
        }

        return list;
    }
}