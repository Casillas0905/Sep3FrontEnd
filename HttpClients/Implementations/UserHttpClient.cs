using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;
    

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<UserDomainModel> Create(UserDomainModel dto)
    {
        Console.WriteLine("CreateAsync method called");
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7093/Users/create", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        UserDomainModel user = JsonSerializer.Deserialize<UserDomainModel>(result)!;
        return user;
    }
    
    public async Task<UserDomainModel> findByUsername(string username)
    {
        Console.WriteLine("1");
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Users/findByUserName/{username}");
        Console.WriteLine("2");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine("3");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        Console.WriteLine("4");
        UserDomainModel user = JsonSerializer.Deserialize<UserDomainModel>(content)!;
        Console.WriteLine("Carlos id:"+user.Id);
        return user;
    }
    
    public async Task<IEnumerable<UserDomainModel>> GetUsers(string? usernameContains = null)
    {
        string uri = "/users";
        if (!string.IsNullOrEmpty(usernameContains))
        {
            uri += $"?username={usernameContains}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<UserDomainModel> users = JsonSerializer.Deserialize<IEnumerable<UserDomainModel>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return users;
    }
    
    public async Task<UserDomainModel> findById(int id)
    {
        Console.WriteLine("1");
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Users/findByUserId/{id}");
        Console.WriteLine("2");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine("3");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        Console.WriteLine("4");
        UserDomainModel user = JsonSerializer.Deserialize<UserDomainModel>(content)!;
        Console.WriteLine("Carlos id:"+user.Id);
        return user;
    }
}