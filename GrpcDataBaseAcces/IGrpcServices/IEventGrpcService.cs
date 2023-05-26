using Domain.Models;

namespace GrpcDataBaseAcces.IGrpcServices;

public interface IEventGrpcService
{
    public Task<IEnumerable<EventDomainModel>> findAllEvents();
    public Task<EventDomainModel> findById(int id);
    public void saveEvent(EventDomainModel eventDomainModel);
    public void updateEvent(EventDomainModel eventDomainModel);
    public void deleteEvent(int id);
}