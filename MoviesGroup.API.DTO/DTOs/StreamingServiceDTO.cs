﻿namespace MoviesGroup.API.DTO;

public class StreamingServicePostDTO
{
    public string Name { get; set; } = string.Empty;
    public OptionType OptionType { get; set; }
    public bool IsSelected { get; set; }
}

public class StreamingServicePutDTO : StreamingServicePostDTO
{
    public int Id { get; set; }
}

public class StreamingServiceGetDTO : StreamingServicePutDTO
{
    // ADD A LIST FOR MOVIES TO LINK IN THE GET FUNCTION, EVENTUALLY.
}
