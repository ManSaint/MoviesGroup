namespace MoviesGroup.Data.Services;

public interface IDbService
{
    Task<List<TDto>> GetAsync<TEntity, TDto>()
            where TEntity : class
            where TDto : class;

    Task<List<TDto>> GetSingleAsync<TEntity, TDto>(int id)
        where TEntity : class
        where TDto : class;

    Task<List<TDto>> PostAsync<TEntity, TDto>()
        where TEntity : class
        where TDto : class;

    Task<List<TDto>> PutAsync<TEntity, TDto>(int id)
        where TEntity : class
        where TDto : class;

    Task<List<TEntity>> DeleteAsync<TEntity>(int id)
        where TEntity : class;
}
