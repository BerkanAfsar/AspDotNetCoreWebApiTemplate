using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Core.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        // Task async için kullanılır

        Task<TEntity> GetByIdAsync(int id); // id ye göre getir

        Task<IEnumerable<TEntity>> GetAllAsync(); // hepsini getir

        //where(x=> x.id = 23)
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate); // koşula uyan birden fazla ürünü getir

        //category.SingleOrDefault(x=> x.name = "pencil")
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate); // koşula uyan tek kaydı getir

        Task AddAsync(TEntity entity); // insert

        Task AddRangeAsync(IEnumerable<TEntity> entities); // bulk insert

        void Remove(TEntity entity); // EntityFramework de remove async olmadığı için Task yok

        void RemoveRange(IEnumerable<TEntity> entities); // bulk remove 

        TEntity Update(TEntity entity);
    }
}
