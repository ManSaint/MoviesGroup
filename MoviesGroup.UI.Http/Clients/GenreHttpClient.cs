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
}