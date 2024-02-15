namespace MoviesGroup.Data.Entities;

public class Movie : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Genre>? Genres { get; set; }
    public List<Actor>? Actors { get; set; }

    public int AgeLimitId { get; set; } // Necessary for one-to-many connections?
    public AgeLimit? AgeLimit { get; set; }
    public int ReleaseYearId { get; set; } //
    public ReleaseYear? ReleaseYear { get; set; }
    public int StreamingServiceId { get; set; } //
    public StreamingService? StreamingService { get; set; }
}
