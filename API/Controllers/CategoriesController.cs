using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        //private readonly IDistributedCache _distributedCache;
        private readonly IMemoryCache _memoryCache;

        public CategoriesController(ICategoryService categoryService, IMemoryCache memoryCache/*, IDistributedCache distributedCache*/)
        {
            _categoryService = categoryService;
            //_distributedCache = distributedCache;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Get All Category
        /// </summary>
        /// <returns></returns>
        [HttpGet/*("Redis")*/("Categories")]
        public IActionResult Get()
        {
            var cacheKey = "categories";
            if(!_memoryCache.TryGetValue(cacheKey,out List<Category> categories))
            {
                categories = _categoryService.GetAll();

                var cacheExprationOptions =
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddHours(6),
                        Priority = CacheItemPriority.Normal,
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    };
                _memoryCache.Set(cacheKey, categories, cacheExprationOptions);
            }
            return Ok(categories);
            //var cacheKey = "categories";
            //string serializedCategoryList;
            //var categories = new List<Category>();
            //var redisCategoryList = _distributedCache.Get(cacheKey);
            //if (redisCategoryList != null)
            //{
            //    serializedCategoryList = Encoding.UTF8.GetString(redisCategoryList);
            //    categories = JsonConvert.DeserializeObject<List<Category>>(serializedCategoryList);
            //}
            //else
            //{
            //    categories = _categoryService.GetAll();
            //    serializedCategoryList = JsonConvert.SerializeObject(categories);
            //    redisCategoryList = Encoding.UTF8.GetBytes(serializedCategoryList);
            //    var options = new DistributedCacheEntryOptions()
            //        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
            //        .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            //    _distributedCache.SetAsync(cacheKey, redisCategoryList, options);
            //}
            //return Ok(categories);
            //    var categories = _categoryService.GetAll();
            //return Ok(categories); //200 + data
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
