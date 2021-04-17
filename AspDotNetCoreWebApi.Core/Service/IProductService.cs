using AspDotNetCoreWebApi.Core.Entity;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Core.Service
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int id);
    }
}
