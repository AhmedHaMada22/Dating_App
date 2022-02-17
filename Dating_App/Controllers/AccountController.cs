using Dating_App.Data;
using Dating_App.DTOs;
using Dating_App.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dating_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDtocs registerDto)          
        {
            if (await UserExists(registerDto.Username))
                return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(Login_Dto lgn)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == lgn.Username);
            if (user == null) return Unauthorized("Invalid username");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computehash = hmac.ComputeHash(Encoding.UTF8.GetBytes(lgn.Password));
              for(int i=0; i< computehash.Length;i++)
            {
                if (computehash[i] != user.PasswordHash[i])
                    return Unauthorized("invalid password");
            }
            return user;
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
