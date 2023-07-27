using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;

namespace API.Controllers

{
    public class ProductsController : BaseApiController

    {
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<ProductType> _productType;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
         private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;
        public ProductsController(
            IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository,
            IMapper mapper)
        {
            _product = productsRepo;
            _productBrand = productBrandRepo;
            _productType = productTypeRepo;
            _mapper = mapper;
             _productTypeRepository = productTypeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsHookAllSpec();
            var products = await _product.ListAsync(spec);
            return Ok(_mapper
                .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsHookAllSpec(id);
            var product = await _product.GetEntityWhithSpec(spec); //replaced GetByIdAsync(id)

            if(product == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }
        [HttpGet("types")]
        public async Task<ActionResult<Product>> GetProductTypes()
        {
            var productType = await _productType.ListAllAsync();
            return Ok(productType);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<Product>> GetProductBrands()
        {
            var productBrand = await _productBrand.ListAllAsync();
            return Ok(productBrand);
        }
/*         [HttpPost]
        public async Task<ActionResult<ProductToReturnDto>> CreateProduct(ProductToCreateDto productToCreate)
        {
            var product = _mapper.Map<ProductToCreateDto, Product>(productToCreate);

            var result = await _product.CreateProductAsync(product);

            if (result <= 0) return BadRequest("Product could not be created.");

            var createdProduct = _mapper.Map<Product, ProductToReturnDto>(product);

            return Ok(createdProduct);
        } */
    }
}