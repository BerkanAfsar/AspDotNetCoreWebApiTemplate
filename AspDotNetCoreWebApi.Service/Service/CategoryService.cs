using AspDotNetCoreWebApi.Core.Entity;
using AspDotNetCoreWebApi.Core.Repository;
using AspDotNetCoreWebApi.Core.Service;
using AspDotNetCoreWebApi.Core.UnitOfWork;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Service.Service
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {

        }

        public async Task<Category> GetWithProductsByIdAsync(int id)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(id);
        }
    }
}
