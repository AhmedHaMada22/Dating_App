using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dating_App.Data;
using Dating_App.Entities;
using Microsoft.AspNetCore.Authorization;
using Dating_App.Interfaces;
using AutoMapper;
using Dating_App.DTOs;

namespace Dating_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users= await _userRepository.GetUsersAsync();
            var userstoreturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(userstoreturn);
        }

        // GET: api/Users/5
        
        [HttpGet("{username}")]
        public async  Task<ActionResult<MemberDto>> GetAppUser(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map< MemberDto>(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAppUser(int id, AppUser appUser)
        //{
        //    if (id != appUser.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(appUser).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AppUserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Users
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        //{
        //    _context.Users.Add(appUser);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
        //}

        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<AppUser>> DeleteAppUser(int id)
        //{
        //    var appUser = await _context.Users.FindAsync(id);
        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(appUser);
        //    await _context.SaveChangesAsync();

        //    return appUser;
        //}

        //private bool AppUserExists(int id)
        //{
        //    return _context.Users.Any(e => e.Id == id);
        //}
    }
}
