using AspDotNetCoreWebApi.Core.Entity;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Core.Service
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int id);
    }
}
