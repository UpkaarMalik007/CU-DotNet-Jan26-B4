using FrontendMVC.ViewModel;
using System.Text.Json;

namespace FrontendMVC.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly HttpClient _httpClient;

        public DestinationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<DestinationViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/destinations");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<DestinationViewModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
        }

        public async Task<DestinationViewModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/destinations/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DestinationViewModel>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
        public async Task CreateAsync(AddDestinationViewModel model)
        {
            await _httpClient.PostAsJsonAsync("api/destinations", model);
        }

        public async Task UpdateAsync(int id, UpdateDestinationViewModel model)
        {
            await _httpClient.PutAsJsonAsync($"api/destinations/{id}", model);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/destinations/{id}");
        }
    }
}

