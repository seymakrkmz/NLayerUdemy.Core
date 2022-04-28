using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ServiceRepository<T> : IGenericRepository<T> where T : class
    {
        //db ile işlem yapmak istediğimiz için appdbcontext tanımlıyoruz
        //temel crud operasyonları hariç bir fonk tanımlamak istersem protected tanımlıyorum
        protected readonly AppDbContext _context;
        //veritabanınmda ki tabloya karşılık geliyor, readonly  ya bu esnada ya da  conctructorda değer atayacağız  başka yerlerde set edilmesin diye
        private readonly DbSet<T>   _dbSet;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); 
        }

        public async Task AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);   
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);   
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            //AsNoTracking ef core çekmiş olduğu dataları memorye almasın, performans açısından
            return _dbSet.AsNoTracking().AsQueryable(); 
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);  
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
           _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);  
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
