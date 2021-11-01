using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;




namespace eCommerceStarterCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet()]
        public IActionResult GetCurrentUserCart()
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var userCart = _context.ShoppingCarts.Where(uc => uc.UserId == userId)
                .Include(c => c.Product)
                .Select(c => new { c.UserId, c.ProductId, c.Product.ProductName, c.Product.ProductDescription, c.Quantity, c.Product.Price, ExtPrice = c.Quantity * c.Product.Price })
                .ToList();
            return Ok(userCart);
        }

        [HttpGet("count")]
        public IActionResult GetItemCount()
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var userCart = _context.ShoppingCarts
                .GroupBy(uc => uc.UserId)
                .Select(uc => new { Count = uc.Count() });

            // returns {count: <int>}
            return Ok(userCart);

        }

        [HttpPut("{productId}")]

        public IActionResult Put(int productId, [FromBody] ShoppingCart value)
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var item = _context.ShoppingCarts.Where(p => (p.UserId == userId && p.ProductId == productId)).SingleOrDefault();
            _context.ShoppingCarts.Remove(item);
            _context.ShoppingCarts.Add(value);
            _context.SaveChanges();
            return Ok(value);

        }

        [HttpPost("{productId}")]

        public IActionResult Post(int productId, [FromBody] ShoppingCart value)
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var chosenObject = _context.ShoppingCarts.Where(co => (co.UserId == userId && co.ProductId == productId)).SingleOrDefault();
            if (chosenObject != null)
            {
                chosenObject.Quantity = chosenObject.Quantity + value.Quantity;
                _context.ShoppingCarts.Update(chosenObject);
            }
            else
            {
                _context.ShoppingCarts.Add(value);
            }
            _context.SaveChanges();
            return StatusCode(201, chosenObject);
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var item = _context.ShoppingCarts.Where(u => (u.UserId == userId && u.ProductId == productId)).SingleOrDefault();
            _context.ShoppingCarts.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}