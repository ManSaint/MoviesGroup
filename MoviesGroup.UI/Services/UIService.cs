namespace MoviesGroup.UI.Services;
public class UIService(GenreHttpClient genreHttp)
{
    List<GenreGetDTO> Genres { get; set; } = [];
    public List<LinkGroup> GenreLinkGroups { get; private set; } =
    [
        new LinkGroup
        {
            Name = "Genres",
            LinkOptions = new(){
                new LinkOption { Id = 1, Name = "Women", IsSelected = true },
                new LinkOption { Id = 2, Name = "Men", IsSelected = false },
                new LinkOption { Id = 3, Name = "Children", IsSelected = false }
            }
        }
    ];
    public int CurrentGenreId { get; set; }
}