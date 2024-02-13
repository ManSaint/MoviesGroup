using MoviesGroup.API.DTO;
using System.Text.Json;

namespace MoviesGroup.UI.Http;
public class GenreHttpClient
{
    private readonly HttpClient _httpClient;
    string _baseAddress = "https://localhost:5000/api/";

    public GenreHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"{_baseAddress}categorys");
    }

    public async Task<List<GenreGetDTO>> GetGenresAsync()
    {
        try
        {
            using HttpResponseMessage response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<List<GenreGetDTO>>(await response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? [];
        }
        catch (Exception ex)
        {
            return [];
        }
    }
}