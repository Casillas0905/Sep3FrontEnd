using System.Net.Http.Json;
using System.Text.Json;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class MessageHttpClient : IMessagesService
{
    private readonly HttpClient client;

    public MessageHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<MessageDomainModel> findById(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Message/findById/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        MessageDomainModel message = JsonSerializer.Deserialize<MessageDomainModel>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return message;
    }

    public async Task<IEnumerable<MessageDomainModel>> findAllMessagesForAChat(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Message/findByChatId/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<MessageDomainModel> messages = JsonSerializer.Deserialize<IEnumerable<MessageDomainModel>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return messages;
    }

    public async Task saveMessage(MessageDomainModel messageDomainModel)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7093/Message/create",messageDomainModel);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public void deleteMessage(int id)
    {
        throw new NotImplementedException();
    }
}