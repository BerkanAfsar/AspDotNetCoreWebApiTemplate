using AspDotNetCoreWebApi.Core.Entity;
using AspDotNetCoreWebApi.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; } // context i appdbcontext e çeviriyoruz çünkü appdbcontextin üzerinde product ve category var
        public ProductRepository(AppDbContext context) : base(context) // Repository.cs deki constructor yüzünden base ile onun consu na gönderiyoruz.
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int id)
        {
           return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
