using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using GrpcDataBaseAcces.GrpcServices;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    
    UserGrpcService Service= new UserGrpcService();

    public UserLogic()
    {
    }
    
    private static void ValidateData(UserDomainModel userDomainModel)
    {
        string userName = userDomainModel.Username;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }

    public void saveAsync(UserDomainModel userDomainModel)
    {
        UserDomainModel? existing = Service.findByUsername(userDomainModel.Username);
        Console.WriteLine("User logic called 2"+existing.Username);
        if (!(existing.Username.Equals("niull")))
        {
            Console.WriteLine("User take");
            throw new Exception("Username already taken");
        }
        //ValidateData(userDomainModel);
        Service.saveUser(userDomainModel);
    }

    public Task<IEnumerable<UserDomainModel>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public UserDomainModel findById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDomainModel> findByUsername(string username)
    {
        UserDomainModel? existing = Service.findByUsername(username);
        //Console.WriteLine("User logic called 2"+existing.Username);
        if (existing.Username.Equals("niull"))
        {
            Console.WriteLine("User not found");
            throw new Exception("Username not found");
        }

        return existing;
    }

    public void updateUser(UserDomainModel userDomainModel)
    {
        throw new NotImplementedException();
    }

    public void deleteUser(int id)
    {
        throw new NotImplementedException();
    }
}