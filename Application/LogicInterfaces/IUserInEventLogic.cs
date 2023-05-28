using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserInEventLogic
{
    public Task<IEnumerable<UserDomainModel>> findAllUsersForOneEvent(int id);
    public void saveUsersInEvents(UserInEventDomainModel userInEventDomainModel);
    public void deleteUser(UserInEventDomainModel userInEventDomainModel);
}