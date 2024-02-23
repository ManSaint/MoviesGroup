namespace MoviesGroup.API.DTO;

public class AgeLimitPostDTO
{
    public int Limit { get; set; }
    public OptionType OptionType { get; set; }
}

public class AgeLimitPutDTO : AgeLimitPostDTO
{
    public int Id { get; set; }
}

public class AgeLimitGetDTO : AgeLimitPutDTO
{
    public bool IsSelected { get; set; }
    // ADD A LIST FOR MOVIES TO LINK IN THE GET FUNCTION, EVENTUALLY.
}
