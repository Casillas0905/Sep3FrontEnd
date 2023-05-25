using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Service;

public class AuthService : IAuthService
{
    private IUserLogic userLogic;

    public AuthService(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }
    
    
    public async Task<UserDomainModel> ValidateUser(string username, string password)
    {
        UserDomainModel user = await userLogic.findByUsername(username);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!user.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return user;
    }

    
    public Task RegisterUser(UserDomainModel user)
    {

        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        userLogic.saveAsync(user);
        
        return Task.CompletedTask;
    }
}