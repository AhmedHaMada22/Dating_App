using Dating_App.Entities;
using Dating_App.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_App.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
       // private readonly IMapper _mapper;
        public UserRepository(DataContext context)
        {
            //_mapper = mapper;
            _context = context;
        }
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async  Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == username);
        }

        public Task<string> GetUserGender(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {

            return await _context.Users.Include(p => p.Photos).ToListAsync();
        }

        public async Task<bool> SavelAsync()
        {

            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
