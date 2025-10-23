using generic_repo_pattern_api.Data;
using generic_repo_pattern_api.Entity;
using Microsoft.EntityFrameworkCore;

namespace generic_repo_pattern_api.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsbyName(string productname)
        {
            return await _dbSet.Where(p => p.ProductName.Contains(productname)).ToListAsync();
        }
    }
}
