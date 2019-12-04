using SlugClubYBBA.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlugClubYBBA.API.Data
{
    public interface IAuthRepository
    {
        Task<Musteri> Register(Musteri musteri);
        Task<Musteri> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}
