using Domain.Models;

namespace GrpcDataBaseAcces.IGrpcServices;

public interface IUserInEventGrpcService
{
    public IEnumerable<UserDomainModel> findAllUsersForOneEvent(int id);
    public void saveUsersInEvents(UserInEventDomainModel userInEventDomainModel);
    public void deleteUser(UserInEventDomainModel userInEventDomainModel);
}