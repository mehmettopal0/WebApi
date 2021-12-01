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
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Get All Category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories); //200 + data
        }
        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        // [Route("getCategoryById/{id}")] => api/category/getCategoryById/2
        public IActionResult Get(int id)
        {
            var categories = _categoryService.GetById(id);
            return Ok(categories); //200 + data
        }
        /// <summary>
        /// Create a Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Category category)
        {
            _categoryService.Add(category);
            return Ok();
            
        }
        /// <summary>
        /// Update the Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Category category)
        {
            if (_categoryService.GetById(category.CategoryId) != null)
            {
                _categoryService.Update(category);
                return Ok("Kategori güncelleme işlemi başarılı..");
            }
            return NotFound("Başarısız!!!!");

        }
        /// <summary>
        /// Delete the Category
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_categoryService.GetById(id) != null)
            {
                _categoryService.Delete(id);
                return Ok("Kategori silme işlemi başarılı..");
            }
            return NotFound("Böyle bir kategori bulunamadı!!!");

        }

    }
}
