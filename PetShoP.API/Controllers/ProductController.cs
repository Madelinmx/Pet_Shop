using Microsoft.AspNetCore.Mvc;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Interfaces;
using PetShop.Infrastructure.Models; 

namespace PetShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] ProductModel model)
        {
            
            var newProduct = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
                CategoryId = model.CategoryId
            };
            await _productRepository.Add(newProduct);
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

       
    }
}