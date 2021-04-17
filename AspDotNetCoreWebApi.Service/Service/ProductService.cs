using AspDotNetCoreWebApi.Core.Entity;
using AspDotNetCoreWebApi.Core.Repository;
using AspDotNetCoreWebApi.Core.Service;
using AspDotNetCoreWebApi.Core.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Service.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(id);
        }
    }
}
