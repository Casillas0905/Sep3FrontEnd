using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserDomainModel dto);
    Task<IEnumerable<User>> GetUsers(string? usernameContains = null);
}