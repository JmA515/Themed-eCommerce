using eCommerceStarterCode.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/Products")]
    [ApiController]

    public class ProductController : Controller
    {
        private ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        // <baseurl>/api/products
        [HttpGet]
        public IActionResult GetProduct()
        {
            var books = _context.Products;
            return Ok(books);
        }

        // <baseurl>/api/products
        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            var books = _context.Products
                .Where(p => p.ProductId == productId)
                .SingleOrDefault();
            return Ok(books);
        }
    }


}
