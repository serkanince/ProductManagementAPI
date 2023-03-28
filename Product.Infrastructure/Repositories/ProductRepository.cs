using Product.Application.Contract;
using Product.Domain.Entites;
using Product.Infrastructure.Persistence;

namespace Product.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(ProductDBContext dbContext) : base(dbContext)
        {
        }
    }
}
