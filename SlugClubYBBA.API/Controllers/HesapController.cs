using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlugClubYBBA.API.Data;
using SlugClubYBBA.API.Models;

namespace SlugClubYBBA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HesapController : ControllerBase
    {
        private IAppRepository _appRepository;
        public HesapController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        public ActionResult GetHesap()
        {
            var hesaps = _appRepository.GetHesaps();
            return Ok(hesaps);
        }
        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]Hesap hesap)
        {
            _appRepository.Add(hesap);
            _appRepository.SaveAll();
            return Ok(hesap);
        }
        [HttpPost]
        [Route("update")]
        public ActionResult Update([FromBody]Hesap hesap)
        {
            _appRepository.Update(hesap);
            _appRepository.SaveAll();
            return Ok(hesap);
        }
    }
}