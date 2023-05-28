using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClasses.Message;
using GrpcDataBaseAcces.IGrpcServices;

namespace GrpcDataBaseAcces.GrpcServices;

public class MessageGrpcService : IMessageGrpcService
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private Messages.MessagesClient client = new Messages.MessagesClient(channel);

    public MessageDomainModel findById(int id)
    {
        var req = new MessageIdRequested() { Id = id };
        var message= client.findById(req);
        MessageDomainModel newMessage = new MessageDomainModel(
            message.Id, message.UserSentId, message.ChatId,message.Date, message.Message);
        return newMessage;
    }

    public async Task<IEnumerable<MessageDomainModel>> findAllMessagesForAChat(int id)
    {
        var req = new ChatIdRequested(){ChatId = id};
        using var call = client.findAllMessagesForAChat(req);
        List<MessageDomainModel> list = new List<MessageDomainModel>();

        while (await call.ResponseStream.MoveNext())
        {
            var message = call.ResponseStream.Current;
            MessageDomainModel userDomain = new MessageDomainModel(message.Id,message.UserSentId,
                message.ChatId, message.Date, message.Message);
            list.Add(userDomain);
        }

        return list;
    }

    public void saveMessage(MessageDomainModel messageDomainModel)
    {
        MessageModel message = new MessageModel()
        {
            Id = messageDomainModel.id,
            Message = messageDomainModel.message,
            ChatId = messageDomainModel.chatId,
            UserSentId = messageDomainModel.userSentId,
            Date = messageDomainModel.date
        };
        client.saveMessageAsync(message);
    }

    public void deleteMessage(int id)
    {
        var req = new MessageIdRequested() { Id = id };
        client.deleteMessageAsync(req);
    }
}