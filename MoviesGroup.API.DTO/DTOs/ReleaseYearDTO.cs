namespace MoviesGroup.API.DTO;

public class ReleaseYearPostDTO
{
    public int Year { get; set; }
    public OptionType OptionType { get; set; }
    public bool IsSelected { get; set; }
}

public class ReleaseYearPutDTO : ReleaseYearPostDTO
{
    public int Id { get; set; }
}

public class ReleaseYearGetDTO : ReleaseYearPutDTO
{
    // ADD A LIST FOR MOVIES TO LINK IN THE GET FUNCTION, EVENTUALLY.
}
