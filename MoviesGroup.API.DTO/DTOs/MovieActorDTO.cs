namespace MoviesGroup.API.DTO;

public class MovieActorPostDTO
{
    public int ActorId { get; set; }
    public int MovieId { get; set; }
}
public class MovieActorDeleteDTO : MovieActorPostDTO
{
}
public class MovieActorGetDTO : MovieActorPostDTO
{
}

public class MovieActorSmallGetDTO
{
    public int ActorId { get; set; }
}