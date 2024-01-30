using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructue.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productsBrand;
        private readonly IGenericRepository<ProductType> _productsType;
        private readonly IMapper _mapper;
        
        public ProductsController(IGenericRepository<Product> productsRepo,IGenericRepository<ProductBrand> productsBrand
        ,IGenericRepository<ProductType> productsType , IMapper mapper )
        {
            _mapper = mapper;
            _productsBrand = productsBrand;
            _productsRepo = productsRepo;
            _productsType = productsType;      
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string sort
        ,int?BrandId , int? typeId)
        {
            var  spec = new ProductsWithTypesAndBrandsSpecification(sort, BrandId, typeId);
            var products = await _productsRepo.ListAsync(spec);

            return Ok(_mapper
            .Map<IReadOnlyList<Product> , IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)] // to tell swagger the possible errors that can be generate from this api
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var  spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            if (product == null ) // in case the product dosen't exist
                return NotFound(new ApiResponse(404));   


            return _mapper.Map<Product , ProductToReturnDto>(product);
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