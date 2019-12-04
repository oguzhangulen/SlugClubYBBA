using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlugClubYBBA.API.Data;
using SlugClubYBBA.API.Dtos;
using SlugClubYBBA.API.Models;

namespace SlugClubYBBA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IAuthRepository _authRepository;
        public MusteriController(IAppRepository appRepository, IAuthRepository authRepository)
        {
            _authRepository = authRepository;
            _appRepository = appRepository;
        }
        public ActionResult GetAll()
        {
            var musteris = _appRepository.GetMusteris();
            return Ok(musteris);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]MusteriRegisterDto musteriRegisterDto)
        {
            if (await _authRepository.UserExists(musteriRegisterDto.TCKN))
                ModelState.AddModelError("UserExist", "Username already exists");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int myRandomNo;
            while (true)
            {
                Random rnd = new Random();
                myRandomNo = rnd.Next(10000000, 99999999);
                if (UniqueHesapNo(myRandomNo.ToString()))
                    break;
            }
            Musteri musteri = new Musteri
            {
                Ad = musteriRegisterDto.Ad,
                Soyad = musteriRegisterDto.Soyad,
                TCKN = musteriRegisterDto.TCKN,
                Sifre = musteriRegisterDto.Sifre,
                Adres = musteriRegisterDto.Adres,
                EPosta = musteriRegisterDto.EPosta,
                TelNo = musteriRegisterDto.TelNo,
            };
            var remusteri = await _authRepository.Register(musteri);
            if (remusteri == null)
                return BadRequest(ModelState);
            Hesap hesap = new Hesap
            {
                AktiflikDurumu = true,
                BakiyeBilgi = 0,
                EkNo = 1000,
                HesapNo = myRandomNo.ToString(),
                Musteri = musteri,
                TCKN = musteri.TCKN
            };
            _appRepository.Add(hesap);

            if (!_appRepository.SaveAll())
                return BadRequest(ModelState);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            var user = await _authRepository.Login(userForLoginDto.UserName, userForLoginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //        new Claim(ClaimTypes.Name, user.UserName)
            //    }),
            //    Expires = DateTime.Now.AddDays(1),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
            //        , SecurityAlgorithms.HmacSha512Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var tokenString = tokenHandler.WriteToken(token);

            return Ok();
        }

        public bool UniqueHesapNo(string hesapno)
        {
            if (_appRepository.GetHesaps().Where(x => x.HesapNo == hesapno) != null)
                return false;
            return true;
        }

    }
}