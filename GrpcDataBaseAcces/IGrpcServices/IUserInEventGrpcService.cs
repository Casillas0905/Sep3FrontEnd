using Domain.Models;

namespace GrpcDataBaseAcces.IGrpcServices;

public interface IUserInEventGrpcService
{
    public Task<IEnumerable<UserDomainModel>> findAllUsersForOneEvent(int id);
    public void saveUsersInEvents(UserInEventDomainModel userInEventDomainModel);
    public void deleteUser(UserInEventDomainModel userInEventDomainModel);
}