namespace MoviesGroup.API.DTO;

public class MoviePostDTO
{
    public string? Name { get; set; } = string.Empty;
    public int AgeLimitId { get; set; }
    public int ReleaseYearId { get; set; }
    public int StreamingServiceId { get; set; }
    //public string? Description { get; set; } = string.Empty;
}

public class MoviePutDTO : MoviePostDTO
{
    public int Id { get; set; }
}

public class MovieGetDTO : MoviePutDTO
{
    //public List<GenreSmallGetDTO>? Genres { get; set; }
    public List<GenreGetDTO>? Genres { get; set; } // Might require migration and database update to make it work.
    public List<ActorGetDTO>? Actors { get; set; }
    public ReleaseYearGetDTO? ReleaseYear { get; set; } // Check which need to be List and which do not.
    public StreamingServiceGetDTO? StreamingService { get; set; }
    public AgeLimitGetDTO? AgeLimit { get; set; }    
}
