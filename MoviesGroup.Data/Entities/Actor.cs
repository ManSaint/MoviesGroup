namespace MoviesGroup.Data.Entities;

public class Actor : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public OptionType OptionType { get; set; }
    public List<Movie> Movies { get; set; }
}
