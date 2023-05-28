using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<UserDomainModel> Create(UserDomainModel dto);
    Task<UserDomainModel> findByUsername(string username);
    Task<IEnumerable<UserDomainModel>> GetUsers(string? usernameContains = null);
    Task<UserDomainModel> findById(int id);
}