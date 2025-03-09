using EventManagement.Models.Entities;
using Newtonsoft.Json;
using System.Net.Http;

namespace EventManagement.Services
{
    public class EventApiClient : IEventApiClient

    {
        private readonly HttpClient _httpClient;

        public EventApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Event> CreateEventAsync(Event createEvent)
        {
            var json = JsonConvert.SerializeObject(createEvent);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("events", content);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Event>(result);
        }

        public async Task<Event> GetEventAsync(int id)
        {
            var response = await _httpClient.GetAsync($"events/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Event>(result);
        }

        public async Task<ICollection<Event>> GetAllEventsAsync()
        {
            var response = await _httpClient.GetAsync("events");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<Event>>(result);
        }
        public async Task UpdateEventAsync(int id, Event updateEvent)
        {
            var json = JsonConvert.SerializeObject(updateEvent);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"events/{id}", content);
            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteEventAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"events/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
