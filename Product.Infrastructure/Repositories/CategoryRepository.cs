using Product.Application.Contract;
using Product.Domain.Entites;
using Product.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositories
{
    internal class CategoryRepository : RepositoryBase<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(ProductDBContext dbContext) : base(dbContext)
        {
        }
    }
}
