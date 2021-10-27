using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/review/")]
    [ApiController]
    public class ReviewController : Controller
    {
        private ApplicationDbContext _context;
        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        //Get all reviews
        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var reviews = _context.Reviews;
            return Ok(reviews);
        }

        //Get api/review/{productId}
        [HttpGet("{productId")]
        public IActionResult GetProductReviews(int productId)
        {
            var reviews = _context.Reviews.Where(r => r.ProductId == productId).ToList();
            return Ok(reviews);
        }

        //Post api/review/
        [HttpPost]
        public IActionResult PostReview([FromBody]Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return StatusCode(201, review);
        }

        //Delete
        [HttpDelete("delete/{reviewId}")]
        public IActionResult DeleteProduct(int reviewId)
        {
            Product product = _context.Products.Where(b => b.Id == reviewId).SingleOrDefault();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}
