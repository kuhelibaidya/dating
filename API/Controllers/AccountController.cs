using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
    
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context,ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerdto )
        {
            if(await UserExist(registerdto.Username)) return BadRequest("User already exist");
            using var hmac = new HMACSHA512();

            var user = new AppData
            {
                username = registerdto.Username.ToLower(),
                passwordHash =hmac.ComputeHash(Encoding.UTF8.GetBytes(registerdto.Password)),
                passwordSalt=hmac.Key,
                KnownAs=registerdto.KnownAs,
                City=registerdto.City,
                Country=registerdto.Country,
                Interests=registerdto.Interests,
                DateOfBirth=registerdto.DateOfBirth,
                
               

            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                username=user.username,
                token=_tokenService.CreateToken(user)

            };
        }
         [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto logindto ){
            var user= await _context.Users.SingleOrDefaultAsync(x=>x.username==logindto.Username);
            if(user==null) return Unauthorized("Invalid username");

            using var hmac=new HMACSHA512(user.passwordSalt);
            var ComputeHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.Password));
            for(int i=0;i<ComputeHash.Length;i++)
            {
                if(ComputeHash[i]!=user.passwordHash[i]) return Unauthorized("Invalid password");
            }
            return new UserDto
            {
                username=user.username,
                token=_tokenService.CreateToken(user),
               
                
                


            };
            
        }

        private async Task<bool> UserExist(string uname)
        {
             return await _context.Users.AnyAsync(x =>x.username==uname.ToLower());
        }
    }
}