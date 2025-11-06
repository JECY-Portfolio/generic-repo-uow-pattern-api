using AutoMapper;
using generic_repo_pattern_api.Entity;
using generic_repo_pattern_api.Repository;
using generic_repo_pattern_api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace generic_repo_pattern_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithGenericRepoController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public ProductWithGenericRepoController(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("ProductsWithPagging")]
        public async Task<IActionResult> ProductsWithPagging(int page = 1, int pageSize = 10, string searchTerm = null)
        {
            var products = await _productRepository.GetAllAsync();
            var prudctdto = _mapper.Map<List<ProductRequest>>(products);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = _mapper.Map<ProductRequest>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest product)
        {
            //var newProduct = new Product
            //{
            //    ProductName = product.ProductName,
            //    Price = product.Price
            //};
            var newProduct = _mapper.Map<Product>(product);
            var createdProduct = await _productRepository.AddAsync(newProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.ProductId }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequest product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            //existingProduct.ProductName = product.ProductName;
            //existingProduct.Price = product.Price;
            _mapper.Map(product, existingProduct);
            await _productRepository.UpdateAsync(existingProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(existingProduct);
            return NoContent();
        }

    }
}
