namespace MoviesGroup.Data.Services;

public class MovieDbService(MoviesGroupContext db, IMapper mapper) : DbService(db, mapper)
{
    //public override async Task<List<TDto>> GetAsync<TEntity, TDto>()
    //{
    //    //IncludeNavigationsFor<Filter>();
    //    IncludeNavigationsFor<ReleaseYear>();
    //    IncludeNavigationsFor<Actor>();
    //    IncludeNavigationsFor<AgeLimit>();
    //    IncludeNavigationsFor<StreamingService>();
    //    IncludeNavigationsFor<Genre>();
    //    return await base.GetAsync<TEntity, TDto>();
    //}
    public async Task<List<MovieGetDTO>> GetMoviesByGenreAsync(int genreId)
    {
        IncludeNavigationsFor<Actor>();
        IncludeNavigationsFor<AgeLimit>();
        IncludeNavigationsFor<StreamingService>();
        IncludeNavigationsFor<ReleaseYear>();
        var movieIds = GetAsync<MovieGenre>(mg => mg.GenreId.Equals(genreId))
            .Select(pc => pc.MovieId);
        var movies = await GetAsync<Movie>(m => movieIds.Contains(m.Id)).ToListAsync();
        return MapList<Movie, MovieGetDTO>(movies);
    }
    public List<TDto> MapList<TEntity, TDto>(List<TEntity> entities)
    where TEntity : class
    where TDto : class
    {
        return mapper.Map<List<TDto>>(entities);
    }
}
