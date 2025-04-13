using MaverickBankReal.Context;
using MaverickBankReal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MaverickBankReal.Repo
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class
    {
        protected readonly BankDbContext _context;
        public Repository(BankDbContext context)
        {
            _context = context;
        }

        public abstract Task<IEnumerable<T>> GetAll();


        public abstract Task<T> GetById(K id);


        public async Task<T> Add(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(K id)
        {
            var entity = await GetById(id);
            if (entity == null)
                throw new Exception("Entity not found");
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<T> Update(K key, T entity)
        {
            var existingEntity = await GetById(key);
            if (existingEntity == null) 
                throw new Exception("Entity not found");

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        
    }
}
