namespace GeoChat.Geolocation.Api.Repo;

public interface IGenericRepo<TEntity> where TEntity : class, new()
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetAsync(object id);
}
