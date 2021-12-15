using API.Authentication;
using AutoMapper;
using Entities;
using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;
        private readonly IMapper _mapper;
        public AuthenticateController(IJWTAuthenticationManager jwtAuthenticationManager, IMapper mapper)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Kimlik Doğrulama İşlemi Başarılı........" };
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authentication([FromBody] UserLoginDto userloginDto)
        {
            var user=_mapper.Map<User>(userloginDto);
            var token = jwtAuthenticationManager.Authenticate(user.Name, user.Phone);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }


    
}
