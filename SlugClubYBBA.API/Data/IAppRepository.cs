using SlugClubYBBA.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlugClubYBBA.API.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        bool SaveAll();

        List<Hesap> GetHesaps();
        List<Musteri> GetMusteris();
        List<HavaleVirman> GetHavaleVirmans();
    }
}
