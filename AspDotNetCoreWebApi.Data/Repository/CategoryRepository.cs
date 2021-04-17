using AspDotNetCoreWebApi.Core.Entity;
using AspDotNetCoreWebApi.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int id)
        {
            return await _appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
