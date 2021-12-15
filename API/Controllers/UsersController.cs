using API.Authentication;
using API.Redis;
using Business.Abstract;
using Business.Concrete;
using Entities;
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
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        //private ICacheService _cacheService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
            //_cacheService = cacheService;
        }
        
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            //if (_cacheService.Any("users"))
            //{
            //    var user = _cacheService.Get<List<User>>("users");
            //    return Ok(user);
            //}
            var users = _userService.GetAll();
            //_cacheService.Add("users", users);

            //var users = _userService.GetAll();
            return Ok(users); //200 + data
        }
        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        // [Route("getUserById/{id}")] => api/user/getUserById/2
        public IActionResult Get(int id)
        {
            var users= _userService.GetById(id);
            if (User != null)
            {
                return Ok(users); //200 + data
            }
            return NotFound("Böyle bir kullanıcı bulunmamaktadır!!!!"); //404
        }
        /// <summary>
        /// Create a User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
         public IActionResult Post([FromBody] User user)
        {
            _userService.Add(user);
            //var users = _userService.GetAll();
            //_cacheService.Add("users", users);
            return Ok("Ekleme işlemi başarılı...Eklenen kişi: "+user.Name); //201 + data
          
        }
        /// <summary>
        /// Update the User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            if (_userService.GetById(user.Id)!=null)
            {
                _userService.Update(user);
                return Ok(user.Name+" adlı kullanıcının bilgileri başarılı bir şekilde güncellendi.");
            }
            return NotFound("Başarısız!!!!");
            
        }
        /// <summary>
        /// Delete the User
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_userService.GetById(id) != null)
            {
                _userService.Delete(id);
                return Ok("Kişi silme işlemi başarılı..");
            }
            return NotFound("Böyle bir kişi bulunamadı!!!");

        }

        

    }
   

}
