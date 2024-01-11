namespace MoviesGroup.Data.Entities;

public class ReleaseYear : IEntity
{
    public int Id { get; set; }
    public int Year { get; set; }
    public List<Movie> Movies { get; set; }
}
