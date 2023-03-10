using Core.CustomSpecifications;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        
        private readonly IGenericRepository<Product> _prodcutRepo;

        public ProductController(IProductRepository repo, IGenericRepository<Product> prodcutRepo)
        {
            _repo = repo;
            _prodcutRepo = prodcutRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProdcut(int id)
        {           
            return await _prodcutRepo.GetByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProdcuts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(6);

            return Ok(await _prodcutRepo.ListAsync(spec));
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
