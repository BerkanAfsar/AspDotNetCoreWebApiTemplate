using AspDotNetCoreWebApi.Core.Entity;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Core.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int id);
    }
}
