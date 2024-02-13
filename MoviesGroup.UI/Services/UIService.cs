using AutoMapper;

namespace MoviesGroup.UI.Services;

public class UIService(GenreHttpClient genreHttp,
    MovieHttpClient movieHttp, IMapper mapper)
{
    List<GenreGetDTO> Genres { get; set; } = [];
    public List<MovieGetDTO> Movies { get; private set; } = [];
    public List<LinkGroup> GenreLinkGroups { get; private set; } =
    [
        new LinkGroup
        {
            Name = "Genres"
            /*,LinkOptions = new(){
                new LinkOption { Id = 1, Name = "Women", IsSelected = true },
                new LinkOption { Id = 2, Name = "Men", IsSelected = false },
                new LinkOption { Id = 3, Name = "Children", IsSelected = false }
            }*/
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

}