using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class UserController : BaseApiController
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppData>>> GetUsers() { 
            return await _context.Users.ToListAsync();
            
         }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppData>> GetUsers(int id) { 
            return await _context.Users.FindAsync(id);
            
    }
}
}