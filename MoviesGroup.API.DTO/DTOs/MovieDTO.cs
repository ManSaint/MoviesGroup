namespace MoviesGroup.API.DTO;

public class MoviePostDTO
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
}

public class MoviePutDTO : MoviePostDTO
{
    public int Id { get; set; }
}

public class MovieGetDto : MoviePutDTO
{
    public List<GenreSmallGetDTO>? Genres { get; set; }
    public List<ActorGetDTO>? Actors { get; set; }
    public List<ReleaseYearGetDTO>? ReleaseYears { get; set; } // Check which need to be List and which do not.
    public List<StreamingServiceGetDTO>? StreamingServices { get; set; }
    public List<AgeLimitGetDTO>? AgeLimits { get; set; }
}
