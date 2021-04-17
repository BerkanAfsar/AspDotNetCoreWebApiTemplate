using AspDotNetCoreWebApi.Core.Repository;
using AspDotNetCoreWebApi.Core.UnitOfWork;
using AspDotNetCoreWebApi.Data.Repository;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IProductRepository Products => _productRepository ??= new ProductRepository(_appDbContext);

        // _productRepository null değilse new la ata değilse direk ata

        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_appDbContext);

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
