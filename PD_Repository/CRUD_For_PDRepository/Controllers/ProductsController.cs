using CRUD_For_PDRepository.Models;
using CRUD_For_PDRepository.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_For_PDRepository.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _productRepository.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productRepository.Update(product);
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Delete(id);
            return NoContent();
        }
    }
}
