namespace BloodBank.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync(int skip = 0, int take = 50);
    Task<TEntity?> GetByIdAsync(int id);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<bool> SaveChangesAsync();
}