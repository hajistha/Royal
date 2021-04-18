using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data;
using core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //private readonly StoreContext _context;
        private readonly IProductRepository _repo;

       // public ProductsController(StoreContext context)
        //{
           // _context = context;
        //}

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        //public ActionResult<List<Product>> GetProducts()
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            //var products = await _context.Products.ToListAsync();
             var products = await _repo.GetProductsAsync();
            return Ok (products);
           // return "this will be a list of products";
        }

        [HttpGet("{id}")]
        //public string GetProduct(int id)
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
           // return await _context.Products.FindAsync(id);
            //return "single product";
        }

        [HttpGet("brands")]
        //public string GetProduct(int id)
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
           // return await _context.Products.FindAsync(id);
            //return "single product";
        }

        [HttpGet("types")]
        //public string GetProduct(int id)
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
           // return await _context.Products.FindAsync(id);
            //return "single product";
        }

    }
}