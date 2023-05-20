using Core.Entities;
using Ifrastructure.Data;
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
        ////asynchronous code
        //// v3
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        //// synchronous code
        //// v2
        // public ActionResult<List<Product>> GetProducts()
        // {
        //     var products = _context.Products.ToList();
        //     return products;
        // }
        //// v01
        // public string GetProducts()
        // {
        //     return "this will be a list of products";
        // }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}