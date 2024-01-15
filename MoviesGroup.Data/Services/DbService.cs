namespace MoviesGroup.Data.Services;

public class DbService : IDbService
{
    private readonly MoviesGroupContext _db;
    private readonly IMapper _mapper;

    public DbService(MoviesGroupContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public virtual async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class
        where TDto : class
    {
        //IncludeNavigationsFor<TEntity>();
        var entities = await _db.Set<TEntity>().ToListAsync(); // Fetching entities from the database, with the help of context above.
        return _mapper.Map<List<TDto>>(entities); // Converting the fetched entities and mapping the entities into a list of DTOs to send.
    }
}
