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
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Users/findByUserName/{username}");
            string content = await response.Content.ReadAsStringAsync();

            // Step 2: Print response status code and content length
            Console.WriteLine("Response StatusCode: " + response.StatusCode);
            Console.WriteLine("Response Content Length: " + content.Length);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }

            UserDomainModel user = ParseUserDomainModel(content);

            // Step 3: Debugging code
            Console.WriteLine("User ID: " + user?.Id);

            return user;
    }

    /*public async Task<UserDomainModel> findByUsername(string username)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Users/findByUserName/{username}");
        string content = await response.Content.ReadAsStringAsync();
    
        // Debugging code
        Console.WriteLine("Response StatusCode: " + response.StatusCode);
        Console.WriteLine("Response Content: " + content);
    
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    
        UserDomainModel user = JsonSerializer.Deserialize<UserDomainModel>(content)!;
    
        // Debugging code
        Console.WriteLine("User ID: " + user?.Id); // Using null conditional operator '?'
    
        return user;
    }*/
    
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
    
    private UserDomainModel ParseUserDomainModel(string json)
{
    JsonDocument document = JsonDocument.Parse(json);

    JsonElement root = document.RootElement;
    int id = root.GetProperty("id").GetInt32();
    string username = root.GetProperty("username").GetString();
    string password = root.GetProperty("password").GetString();
    string email = root.GetProperty("email").GetString();
    string firstName = root.GetProperty("firstName").GetString();
    string lastName = root.GetProperty("lastName").GetString();
    string birthday = root.GetProperty("birthday").GetString();
    string description = root.GetProperty("description").GetString();
    int numberOfMatches = root.GetProperty("number_of_matches").GetInt32();
    string note = root.GetProperty("note").GetString();
    string photo1 = root.GetProperty("photo1").GetString();
    string photo2 = root.GetProperty("photo2").GetString();
    string photo3 = root.GetProperty("photo3").GetString();
    string photo4 = root.GetProperty("photo4").GetString();
    string photo5 = root.GetProperty("photo5").GetString();
    string gender = root.GetProperty("gender").GetString();
    string preference = root.GetProperty("preference").GetString();
    string horoscope = root.GetProperty("horoscope").GetString();
    string occupation = root.GetProperty("occupation").GetString();
    string city = root.GetProperty("city").GetString();
    string education = root.GetProperty("education").GetString();
    bool drink = root.GetProperty("drink").GetBoolean();
    bool administrator = root.GetProperty("administrator").GetBoolean();

    // Create a new UserDomainModel object and populate its properties
    UserDomainModel user = new UserDomainModel
    {
        Id = id,
        Username = username,
        Password = password,
        Email = email,
        FirstName = firstName,
        LastName = lastName,
        Birthday = birthday,
        Description = description,
        Number_of_matches = numberOfMatches,
        Note = note,
        Photo1 = photo1,
        Photo2 = photo2,
        Photo3 = photo3,
        Photo4 = photo4,
        Photo5 = photo5,
        Gender = gender,
        Preference = preference,
        Horoscope = horoscope,
        Occupation = occupation,
        City = city,
        Education = education,
        Drink = drink,
        Administrator = administrator
    };

    return user;
}
}