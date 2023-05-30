using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IEventService
{
    public Task<IEnumerable<EventDomainModel>> findAllEvents();
    public Task<EventDomainModel> findById(int id);
    public Task saveEvent(EventDomainModel eventDomainModel);
    public Task updateEvent(EventDomainModel eventDomainModel);
    public void deleteEvent(int id);
    int id { get; set; }
}