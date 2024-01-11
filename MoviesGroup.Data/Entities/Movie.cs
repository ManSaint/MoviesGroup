namespace MoviesGroup.Data.Entities;

public class Movie : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Genre> Genres { get; set; }
    public List<Actor> Actors { get; set; }
    public AgeLimit? AgeLimit { get; set; }
    public ReleaseYear ReleaseYear { get; set; }
    public StreamingService StreamingService { get; set; }
}
