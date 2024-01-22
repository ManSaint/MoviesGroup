namespace MoviesGroup.API.DTO;

public class ReleaseYearPostDTO
{
    public int YearNum { get; set; }
}

public class ReleaseYearPutDTO : ReleaseYearPostDTO
{
    public int Id { get; set; }
}

public class ReleaseYearGetDTO : ReleaseYearPutDTO
{

}
