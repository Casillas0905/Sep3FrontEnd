using Application.LogicInterfaces;
using Domain.Models;
using GrpcDataBaseAcces.GrpcServices;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    
    UserGrpcService Service= new UserGrpcService();

    public UserLogic()
    {
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
        return Service.getAllUsers();
    }

    public UserDomainModel findById(int id)
    {
        UserDomainModel? existing = Service.findById(id);
        if (existing.Username.Equals("niull"))
        {
            Console.WriteLine("User not found");
            throw new Exception("Username not found");
        }
        return existing;
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
        UserDomainModel? existing = Service.findById(userDomainModel.Id);
        if (existing.Username.Equals("niull"))
        {
            Console.WriteLine("User not found");
            throw new Exception("Username not found");
        }
        Service.updateUser(userDomainModel);
    }

    public void deleteUser(int id)
    {
        UserDomainModel? existing = Service.findById(id);
        if (existing.Username.Equals("niull"))
        {
            Console.WriteLine("User not found");
            throw new Exception("Username not found");
        }
        Service.deleteUser(id);
    }
}