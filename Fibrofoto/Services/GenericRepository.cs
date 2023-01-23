using Fibrofoto.Data;
using Microsoft.EntityFrameworkCore;

namespace Fibrofoto.Services
{
    public class GenericRepository<T> : IGenericRepositorys<T> where T : class
    {
        protected FibrofotoContext _context;
        internal DbSet<T> _dbSet;
        public GenericRepository(FibrofotoContext context) 
        {
            _context= context;
            _dbSet= context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async void Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                throw new Exception($"La entidad con el id {id.ToString()} no existe");
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State= EntityState.Modified;
        }
    }
}
