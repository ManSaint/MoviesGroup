namespace MoviesGroup.Data.Services;

public class MovieDbService(MoviesGroupContext db, IMapper mapper) : DbService(db, mapper)
{
    public override async Task<List<TDto>> GetAsync<TEntity, TDto>()
    {
        //IncludeNavigationsFor<Filter>();
        IncludeNavigationsFor<ReleaseYear>();
        IncludeNavigationsFor<Actor>();
        IncludeNavigationsFor<AgeLimit>();
        IncludeNavigationsFor<StreamingService>();
        return await base.GetAsync<TEntity, TDto>();
    }
}
