using AutoMapper;
using Core.CustomSpecifications;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        
        private readonly IGenericRepository<Product> _prodcutRepo;
        
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repo, 
                                 IGenericRepository<Product> prodcutRepo,
                                 IMapper mapper)
        {
            _repo = repo;
            _prodcutRepo = prodcutRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProdcut(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _prodcutRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet]
        [ServiceFilter(typeof(TestAsyncActionFilter))]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProdcuts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await _prodcutRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProdcutBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProdcutTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}
