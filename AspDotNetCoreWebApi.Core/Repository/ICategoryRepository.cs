using AspDotNetCoreWebApi.Core.Entity;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Core.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int id);
    }
}
