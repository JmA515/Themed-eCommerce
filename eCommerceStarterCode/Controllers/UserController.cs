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
    [Route("api/users/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("user")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users;
            return Ok(users);
        }

        
        [HttpGet("{userId}")]
        public IActionResult GetCurrentUser(string userId)
        {
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        
    }
}
