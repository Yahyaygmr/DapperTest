namespace DapperTest.Services.Abstracts
{
    public interface IGenericService<T> where T : class , new()
    {
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T item);
        Task DeleteAsync(int id);
        Task UpdateAsync(T item);
        Task<T> GetAsync(int id);
    }
}
