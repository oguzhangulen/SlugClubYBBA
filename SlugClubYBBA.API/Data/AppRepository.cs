using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlugClubYBBA.API.Models;

namespace SlugClubYBBA.API.Data
{
    public class AppRepository : IAppRepository
    {
        private DataContext _context;
        public AppRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<HavaleVirman> GetHavaleVirmans()
        {
            var havalevirmans = _context.HavaleVirman.ToList();
            return havalevirmans;
        }

        public List<Hesap> GetHesaps()
        {
            var hesaps = _context.Hesap.ToList();
            return hesaps;
        }

        public List<Musteri> GetMusteris()
        {
            var musteris = _context.Musteri.Include(c => c.Hesaps).ToList();
            return musteris;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
