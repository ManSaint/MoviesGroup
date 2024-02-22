using AutoMapper;
using MoviesGroup.UI.Storage.Services;

namespace MoviesGroup.UI.Services;

public class UIService(GenreHttpClient genreHttp,
    MovieHttpClient movieHttp, IMapper mapper, IStorageService storage)
{
    List<GenreGetDTO> Genres { get; set; } = [];
    public List<MovieGetDTO> Movies { get; private set; } = [];
    public List<CartItemDTO> CartItems { get; set; } = [];
    public List<LinkGroup> GenreLinkGroups { get; private set; } =
    [
        new LinkGroup
        {
            Name = "Genres"
        }
    ];
    public int CurrentGenreId { get; set; }

    public async Task GetLinkGroup()
    {
        Genres = await genreHttp.GetGenresAsync();
        GenreLinkGroups[0].LinkOptions = mapper.Map<List<LinkOption>>(Genres);
        var linkOption = GenreLinkGroups[0].LinkOptions.FirstOrDefault();
        linkOption!.IsSelected = true;
    }

    public async Task OnGenreLinkClick(int id)
    {
        CurrentGenreId = id;
        await GetMoviesAsync();
        GenreLinkGroups[0].LinkOptions.ForEach(l => l.IsSelected = false);
        GenreLinkGroups[0].LinkOptions.Single(l => l.Id.Equals(CurrentGenreId)).IsSelected = true;
    }

    public async Task GetMoviesAsync() =>
        Movies = await movieHttp.GetMoviesAsync(CurrentGenreId);

    public async Task<T> ReadStorage<T>(string key)// where T : class
    {
        //if (string.IsNullOrEmpty(key) || storage is null) return new T();
        return await storage.GetAsync<T>(key);
    }
    public async Task<T> ReadSingleStorage<T>(string key)// where T : class
    {
        return await storage.GetAsync<T>(key);
    }

    public async Task SaveToStorage<T>(string key, T value)// where T : class
    {
        if (string.IsNullOrEmpty(key) || storage is null) return;
        await storage.SetAsync<T>(key, value);
    }
    public async Task RemoveFromStorage(string key)// where T : class
    {
        if (string.IsNullOrEmpty(key) || storage is null) return;
        await storage.RemoveAsync(key);
    }
}