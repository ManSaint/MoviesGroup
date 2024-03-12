using System.Text;

namespace MoviesGroup.UI.Http;

public class ActorHttpClient
{
    private readonly HttpClient _httpClient;
    private string _baseAddress = "https://localhost:6500/api/";

    public ActorHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"{_baseAddress}actors");
    }

    public async Task<List<ActorGetDTO>> GetAllActorsAsync()
    {
        try
        {
            using HttpResponseMessage response = await _httpClient.GetAsync(string.Empty); // No need for a relative path
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<ActorGetDTO>>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? [];
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., log or throw)
            return [];
        }
    }

    public async Task<List<ActorGetDTO>> GetSingleActorAsync(int actorId)
    {
        try
        {
            // Use the relative path, not the base address here

            string relativePath = $"actors/{actorId}";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<ActorGetDTO>>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? [];
        }
        catch (Exception ex)
        {
            return [];
        }
    }

    public async Task AddActorAsync(ActorPostDTO actor)
    {
        try
        {
            // Serialize the actor object to JSON
            var jsonContent = JsonSerializer.Serialize(actor);

            // Send a POST request to the API endpoint
            using var response = await _httpClient.PostAsync("", new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            // Optionally, you can add further handling if needed
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., log or throw)
        }
    }

    public async Task UpdateActorAsync(int actorId, ActorPutDTO actor)
    {
        try
        {
            // Serialize the actor object to JSON
            var jsonContent = JsonSerializer.Serialize(actor);

            // Use the relative path to specify the actor to be updated
            string relativePath = $"actors/{actorId}";

            // Send a PUT request to the API endpoint
            using var response = await _httpClient.PutAsync(relativePath, new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            // Optionally, you can add further handling if needed
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., log or throw)
        }
    }

    public async Task<bool> DeleteActorAsync(int actorId)
    {
        try
        {
            // Use the relative path to specify the actor to be deleted
            string relativePath = $"actors/{actorId}";

            // Send a DELETE request to the API endpoint
            using var response = await _httpClient.DeleteAsync(relativePath);
            response.EnsureSuccessStatusCode();

            // If the request is successful, return true
            return true;
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., log or throw)
            return false;
        }
    }
}