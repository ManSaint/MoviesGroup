namespace MoviesGroup.API.DTO;

public class GenrePostDTO
{
    public string Name { get; set; } = string.Empty;
}

public class GenrePutDTO : GenrePostDTO
{
    public int Id { get; set; }
}

public class GenreGetDTO : GenrePutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
    //public List<MovieGetDTO>? Movies { get; set; }
}

public class GenreSmallGetDTO : GenrePutDTO
{
}
