using Domain.Models;

namespace GrpcDataBaseAcces.IGrpcServices;

public interface IUserGrpcService
{
    public void saveUser(UserDomainModel user);

    public UserDomainModel findById(int id);

    public Task<IEnumerable<UserDomainModel>> getAllUsers();

    public void updateUser(UserDomainModel user);

    public void deleteUser(int id);

    public UserDomainModel findByUsername(string username);
}