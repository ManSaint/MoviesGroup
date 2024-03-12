using AutoMapper;
using MoviesGroup.API.DTO;
using MoviesGroup.UI.Http;

namespace MoviesGroup.UI.Admin.Services;

public class AdminUIService(GenreHttpClient genreHttp,
    MovieHttpClient movieHttp, ActorHttpClient actorHttp, IMapper mapper)
{
    private List<GenreGetDTO> Genres { get; set; } = [];
    public List<MovieGetDTO> Movies { get; private set; } = [];
    public List<ActorGetDTO> Actors { get; private set; } = [];

    public async Task Add(string name)
    {
        var dto = new ActorPostDTO
        {
            Name = name
        };

        await actorHttp.AddActorAsync(dto);
    }

    public async Task GetAllActorsAsync()
    {
        Actors = await actorHttp.GetAllActorsAsync();
    }
}