namespace MoviesGroup.API.DTO;

public class AgeLimitPostDTO
{
    public int AgeNum { get; set; }
    public OptionType OptionType { get; set; }
    public bool IsSelected { get; set; }
}

public class AgeLimitPutDTO : AgeLimitPostDTO
{
    public int Id { get; set; }
}

public class AgeLimitGetDTO : AgeLimitPutDTO
{

}