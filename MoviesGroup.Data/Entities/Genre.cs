namespace MoviesGroup.Data.Entities;

public class Genre : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Movie> Movies { get; set; }
    public List<Filter> Filters { get; set; }
}
