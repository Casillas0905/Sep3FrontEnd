﻿namespace Domain.DTOs;

public class UserLogInDto
{
    public string Username { get; init; }
    public string Password { get; init; }

    public UserLogInDto(string username, string password)
    {
        Username = username;
        Password = password;
    }
}