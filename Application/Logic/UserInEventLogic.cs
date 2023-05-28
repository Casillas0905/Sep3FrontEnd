using Application.LogicInterfaces;
using Domain.Models;
using GrpcDataBaseAcces.GrpcServices;

namespace Application.Logic;

public class UserInEventLogic : IUserInEventLogic
{
    private UserInEventGrpcServices services = new UserInEventGrpcServices();
    public Task<IEnumerable<UserDomainModel>> findAllUsersForOneEvent(int id)
    {
        return services.findAllUsersForOneEvent(id);
    }

    public void saveUsersInEvents(UserInEventDomainModel userInEventDomainModel)
    {
        services.saveUsersInEvents(userInEventDomainModel);
    }

    public void deleteUser(UserInEventDomainModel userInEventDomainModel)
    {
        services.deleteUser(userInEventDomainModel);
    }
}