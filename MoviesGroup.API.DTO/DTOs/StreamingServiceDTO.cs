namespace MoviesGroup.API.DTO;

public class StreamingServicePostDTO
{
    public string Name { get; set; } = string.Empty;
}

public class StreamingServicePutDTO : StreamingServicePostDTO
{
    public int Id { get; set; }
}

public class StreamingServiceGetDTO : StreamingServicePutDTO
{

}
