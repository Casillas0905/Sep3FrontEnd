using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClasses.Event;
using GrpcDataBaseAcces.IGrpcServices;

namespace GrpcDataBaseAcces.GrpcServices;

public class EventGrpcService : IEventGrpcService
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private Events.EventsClient client = new Events.EventsClient(channel);
    
    public async Task<IEnumerable<EventDomainModel>> findAllEvents()
    {
        var req = new Empty();
        using var call = client.findAllEvents(req);
        List<EventDomainModel> list = new List<EventDomainModel>();

        while (await call.ResponseStream.MoveNext())
        {
            var events = call.ResponseStream.Current;
            EventDomainModel userDomain = new EventDomainModel(events.Id,events.Description,events.Title, events.MadeById);
            list.Add(userDomain);
        }

        return list;
    }

    public async Task<EventDomainModel> findById(int id)
    {
        var req = new EventIdRequest() { Id = id };
        var chat= client.findById(req);
        EventDomainModel newChat = new EventDomainModel(
            chat.Id,chat.Description, chat.Title, chat.MadeById);
        return newChat;
    }

    public void saveEvent(EventDomainModel eventDomainModel)
    {
        var events = new EventModel()
        {
            Id = eventDomainModel.id, Description = eventDomainModel.description,
            MadeById = eventDomainModel.madeById, Title = eventDomainModel.title
        };
        client.saveEventAsync(events);
    }

    public void updateEvent(EventDomainModel eventDomainModel)
    {
        var events = new EventModel()
        {
            Id = eventDomainModel.id, Description = eventDomainModel.description,
            MadeById = eventDomainModel.madeById, Title = eventDomainModel.title
        };
        client.updateEventAsync(events);
    }

    public void deleteEvent(int id)
    {
        var req = new EventIdRequest() { Id = id };
        client.deleteEventAsync(req);
    }
}