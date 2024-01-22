namespace MoviesGroup.API.DTO;

public class ActorPostDTO
{
    public string Name { get; set; } = string.Empty;
}

public class ActorPutDTO : ActorPostDTO
{
    public int Id { get; set; }
}

public class ActorGetDTO : ActorPutDTO
{

}
