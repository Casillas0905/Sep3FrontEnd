using System.Net.Http.Json;
using System.Text.Json;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class EventHttpClient : IEventService
{
    private readonly HttpClient client;
    public int id { get; set; }
    public EventHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<EventDomainModel>> findAllEvents()
    {
        
        HttpResponseMessage response = await client.GetAsync("https://localhost:7093/Events/findAll");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<EventDomainModel> events = JsonSerializer.Deserialize<IEnumerable<EventDomainModel>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return events;
    }

    public async Task<EventDomainModel> findById(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7093/Events/findById/{id}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        EventDomainModel events = JsonSerializer.Deserialize<EventDomainModel>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return events;
    }

    public async Task saveEvent(EventDomainModel eventDomainModel)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7093/Events/create",eventDomainModel);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task updateEvent(EventDomainModel eventDomainModel)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7093/Events/update",eventDomainModel);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public void deleteEvent(int id)
    {
        throw new NotImplementedException();
    }
}