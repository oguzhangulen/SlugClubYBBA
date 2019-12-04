using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlugClubYBBA.API.Models;

namespace SlugClubYBBA.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Musteri> Login(string userName, string password)
        {
            var user = await _context.Musteri.FirstOrDefaultAsync(x => x.TCKN == userName);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<Musteri> Register(Musteri musteri)
        {
            await _context.Musteri.AddAsync(musteri);
            await _context.SaveChangesAsync();

            return musteri;
        }

        public async Task<bool> UserExists(string userName)
        {
            if (await _context.Musteri.AnyAsync(x => x.TCKN == userName))
            {
                return true;
            }
            return false;
        }
    }
}
