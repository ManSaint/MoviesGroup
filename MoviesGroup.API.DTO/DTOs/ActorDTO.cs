namespace MoviesGroup.API.DTO;

public class ActorPostDTO
{
    public string Name { get; set; } = string.Empty;
    public OptionType OptionType { get; set; }
}

public class ActorPutDTO : ActorPostDTO
{
    public int Id { get; set; }
}

public class ActorGetDTO : ActorPutDTO
{
    //public List<MovieGetDTO>? Movies { get; set; }
    public bool IsSelected { get; set; }
    // ADD A LIST FOR MOVIES TO LINK IN THE GET FUNCTION, EVENTUALLY.
}
