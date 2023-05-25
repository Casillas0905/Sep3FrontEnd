using Application.DaoInterfaces;
using Domain.Models;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    public void saveUser(UserDomainModel user)
    {
        throw new NotImplementedException();
    }

    public UserDomainModel findById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDomainModel>> getAllUsers()
    {
        throw new NotImplementedException();
    }

    public void updateUser(UserDomainModel user)
    {
        throw new NotImplementedException();
    }

    public void deleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public UserDomainModel findByUsername(string username)
    {
        throw new NotImplementedException();
    }
}