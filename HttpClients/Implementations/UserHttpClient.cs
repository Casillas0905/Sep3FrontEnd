using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Users/findByUserName/{username}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        UserDomainModel user = JsonSerializer.Deserialize<UserDomainModel>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
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

        IEnumerable<UserDomainModel> user = JsonSerializer.Deserialize<IEnumerable<UserDomainModel>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }
    
    public async Task<UserDomainModel> findById(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Users/findByUserId/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        UserDomainModel user = JsonSerializer.Deserialize<UserDomainModel>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }

    public async void updateUser(UserDomainModel userDomainModel)
    {
        string adressAsJson = JsonSerializer.Serialize(userDomainModel);
        StringContent body = new StringContent(adressAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PatchAsync("https://localhost:7093/Users/update", body);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}