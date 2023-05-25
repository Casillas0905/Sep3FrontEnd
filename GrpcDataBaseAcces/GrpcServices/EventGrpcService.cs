using Domain.Models;
using GrpcDataBaseAcces.IGrpcServices;

namespace GrpcDataBaseAcces.GrpcServices;

public class EventGrpcService : IEventGrpcService
{
    public IEnumerable<EventDomainModel> findAllEvents()
    {
        throw new NotImplementedException();
    }

    public EventDomainModel findById(int id)
    {
        throw new NotImplementedException();
    }

    public void saveEvent(EventDomainModel eventDomainModel)
    {
        throw new NotImplementedException();
    }

    public void updateEvent(EventDomainModel eventDomainModel)
    {
        throw new NotImplementedException();
    }

    public void deleteEvent(int id)
    {
        throw new NotImplementedException();
    }
}