using generic_repo_pattern_api.Entity;

namespace generic_repo_pattern_api.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsbyName(string productname);
    }
}
