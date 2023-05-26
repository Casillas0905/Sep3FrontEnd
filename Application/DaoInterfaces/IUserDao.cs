using Domain.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    public void saveUser(UserDomainModel user);

    public UserDomainModel findById(int id);

    public Task<IEnumerable<UserDomainModel>> getAllUsers();

    public void updateUser(UserDomainModel user);

    public void deleteUser(int id);

    public UserDomainModel findByUsername(string username);
    
}