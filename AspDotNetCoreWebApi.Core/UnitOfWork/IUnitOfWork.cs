using AspDotNetCoreWebApi.Core.Repository;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        ICategoryRepository Categories { get; }

        Task CommitAsync(); // entiy framework tarafından save changes i çağırcak

        void Commit();
    }
}
