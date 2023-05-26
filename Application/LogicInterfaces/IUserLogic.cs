
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    public void saveAsync(UserDomainModel userDomainModel);
    public Task<IEnumerable<UserDomainModel>> GetAllUsers();
    public UserDomainModel findById(int id);
    public Task<UserDomainModel> findByUsername(string username);
    public void updateUser(UserDomainModel userDomainModel);
    public void deleteUser(int id);
}