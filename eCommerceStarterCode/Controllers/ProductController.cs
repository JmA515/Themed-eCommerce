using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
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
        public IActionResult GetAllProducts()
        {
            var books = _context.Products;
            return Ok(books);
        }

        // <baseurl>/api/products/{productId}
        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            var selectedbook = _context.Products
                .Where(p => p.Id == productId)
                .SingleOrDefault();
            return Ok(selectedbook);
        }

        //Post api/products
        [HttpPost]
        public IActionResult PostProduct([FromBody] Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return StatusCode(201, newProduct);
        }

        //PUT api/products/edit/{productId}
        [HttpPut("edit/{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] Product value)
        {
            var book = _context.Products.Where(b => b.Id == productId).SingleOrDefault();
            if(book == null)
            {
                return NotFound("Requested book not found");
            }
            book.ProductName =  value.ProductName;
            book.ProductDescription = value.ProductDescription;
            book.Price = value.Price;
            book.Genre = value.Genre;

            _context.Products.Update(book);
            _context.SaveChanges();
            return StatusCode(201, book);

        }

        //Delete api/products/delete/{productId}
        [HttpDelete("delete/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            Product product = _context.Products.Where(b => b.Id == productId).SingleOrDefault();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }

    }


}
