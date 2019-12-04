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
    public class HavaleVirmanController : ControllerBase
    {
        private IAppRepository _appRepository;
        public HavaleVirmanController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        public ActionResult GetHavaleVirman()
        {
            var havaleVirman = _appRepository.GetHavaleVirmans();
            return Ok(havaleVirman);
        }
        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]HavaleVirman havaleVirman)
        {
            _appRepository.Add(havaleVirman);
            _appRepository.SaveAll();
            return Ok(havaleVirman);
        }
        [HttpPost]
        [Route("update")]
        public ActionResult Update([FromBody]HavaleVirman havaleVirman)
        {
            _appRepository.Update(havaleVirman);
            _appRepository.SaveAll();
            return Ok(havaleVirman);
        }
    }
}