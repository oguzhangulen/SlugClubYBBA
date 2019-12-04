using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlugClubYBBA.API.Data;

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

    }
}