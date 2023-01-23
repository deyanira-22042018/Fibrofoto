namespace Fibrofoto.Services
{
    public interface IGenericRepositorys<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        void Add (T entity); 
        void Update (T entity);
        void Delete (int id);
    }
}
