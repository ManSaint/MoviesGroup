namespace MoviesGroup.API.DTO;

public class MovieGenrePostDTO
{
    public int GenreId { get; set; }
    public int MovieId { get; set; }
}
public class MovieGenreDeleteDTO : MovieGenrePostDTO
{
}
public class MovieGenreGetDTO : MovieGenrePostDTO
{
}

public class MovieGenreSmallGetDTO
{
    public int GenreId { get; set; }
}