using Core.Entities;
using Core.Interfaces;
using Infrastructue.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productsBrand;
        private readonly IGenericRepository<ProductType> _productsType;
        
        public ProductsController(IGenericRepository<Product> productsRepo,IGenericRepository<ProductBrand> productsBrand
        ,IGenericRepository<ProductType> productsType)
        {
            _productsBrand = productsBrand;
            _productsRepo = productsRepo;
            _productsType = productsType;      
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productsRepo.ListAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productsRepo.GetByIdAsync(id);
        }
        [HttpGet("brands")] //fil url te3 url/api/products/brands (brands is a result of the http)
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productsBrand.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await _productsType.ListAllAsync());
        }

    }

}