using Domain.Models;

namespace GrpcDataBaseAcces.IGrpcServices;

public interface IEventGrpcService
{
    public IEnumerable<EventDomainModel> findAllEvents();
    public EventDomainModel findById(int id);
    public void saveEvent(EventDomainModel eventDomainModel);
    public void updateEvent(EventDomainModel eventDomainModel);
    public void deleteEvent(int id);
}