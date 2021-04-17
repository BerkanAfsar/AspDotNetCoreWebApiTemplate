using AspDotNetCoreWebApi.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context; // extend yerlerde kullanıldığı için protected yaptık
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context; // context ile db ye connection açıyor
            _dbSet = context.Set<TEntity>(); //dbSet ile tabloya erişiyor
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity); // await keyword i addAsync metodu bitene kadar orada kalınmasını sağlar
        
            // async programmingde bir şey dönemeyecekse task yazılır void yerimne geçer
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
             _context.Entry(entity).State = EntityState.Modified; // tablodaki tüm alanları update eder. tabloda çok fazla alan varsa performans sıkıntısı olur

            return entity;
        }
    }
}
