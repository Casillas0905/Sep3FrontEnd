using Application.LogicInterfaces;
using Domain.Models;
using GrpcDataBaseAcces.GrpcServices;

namespace Application.Logic;

public class EventLogic : IEventLogic
{
    private EventGrpcService service = new EventGrpcService();
    public Task<IEnumerable<EventDomainModel>> findAllEvents()
    {
        return service.findAllEvents();
    }

    public Task<EventDomainModel> findById(int id)
    {
        return findById(id);
    }

    public void saveEvent(EventDomainModel eventDomainModel)
    {
        service.saveEvent(eventDomainModel);
    }

    public void updateEvent(EventDomainModel eventDomainModel)
    {
        service.updateEvent(eventDomainModel);
    }

    public void deleteEvent(int id)
    {
       service.deleteEvent(id);
    }
}