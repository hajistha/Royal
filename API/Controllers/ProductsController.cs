using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data;
using core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        //public ActionResult<List<Product>> GetProducts()
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok (products);
           // return "this will be a list of products";
        }

        [HttpGet("{id}")]
        //public string GetProduct(int id)
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
            //return "single product";
        }
    }
}