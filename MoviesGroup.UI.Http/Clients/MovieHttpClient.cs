

using MoviesGroup.API.DTO;
using System.Text.Json;

namespace MoviesGroup.UI.Http.Clients;

public class MovieHttpClient
{
   
    private readonly HttpClient _httpClient;

    string _baseAddress = "https://localhost:5500/api/";

    public MovieHttpClient(HttpClient httpClient)

    {

        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri($"{_baseAddress}products");

    }

    public async Task<List<MovieGetDTO>> GetMoviesAsync(int genreId)

    {

        try

        {

            // Use the relative path, not the base address here

            string relativePath = $"Moviesbygenre/{genreId}";

            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);

            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();

            var result = await JsonSerializer.DeserializeAsync<List<MovieGetDTO>>(resultStream,

                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? [];

        }

        catch (Exception ex)

        {

            return [];

        }

    }
}
