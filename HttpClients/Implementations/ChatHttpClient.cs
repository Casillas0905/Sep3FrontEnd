using System.Text.Json;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class ChatHttpClient : IChatService
{
    private readonly HttpClient client;

    public ChatHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<ChatDomainModel> findById(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Chat/findById/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ChatDomainModel chat = JsonSerializer.Deserialize<ChatDomainModel>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return chat;
    }

    public void deleteChat(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ChatDomainModel>> findByUserId(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Chat/findByUserId/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<ChatDomainModel> chats = JsonSerializer.Deserialize<IEnumerable<ChatDomainModel>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return chats;
    }
}