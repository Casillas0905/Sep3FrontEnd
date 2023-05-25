using Domain.Models;
using GrpcDataBaseAcces.IGrpcServices;

namespace GrpcDataBaseAcces.GrpcServices;

public class UserInEventGrpcServices : IUserInEventGrpcService
{
    public IEnumerable<UserDomainModel> findAllUsersForOneEvent(int id)
    {
        throw new NotImplementedException();
    }

    public void saveUsersInEvents(UserInEventDomainModel userInEventDomainModel)
    {
        throw new NotImplementedException();
    }

    public void deleteUser(UserInEventDomainModel userInEventDomainModel)
    {
        throw new NotImplementedException();
    }
}