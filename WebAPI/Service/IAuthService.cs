using Domain.Models;

namespace WebAPI.Service;

public interface IAuthService
{
    Task<UserDomainModel> ValidateUser(string username, string password);
    Task RegisterUser(UserDomainModel user);
}