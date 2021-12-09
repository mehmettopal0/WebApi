using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        //private IConnectionMultiplexer _redisCache;
        //private IDatabase _db;
        public ProductsController(IProductService productService/*, IConnectionMultiplexer redisCache*/)
        {
            _productService = productService;
            //_redisCache = redisCache;
            //_db = _redisCache.GetDatabase();
        }

        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
            return Ok(products); //200 + data
        }
        [HttpGet("getbycategory")]
        public IActionResult GetAllByCategoryName(int id)
        {
            var result = _productService.GetAllByCategoryName(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        /// <summary>
        /// GetProductById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        // [Route("getProductById/{id}")] => api/products/getProductById/2
        public IActionResult Get(int id)
        {
            //var cachedId = _db.StringGet(id.ToString());
            //if (cachedId.HasValue)
            //{
            //    return (IActionResult)JsonSerializer.Deserialize<Product>(cachedId);
            //}
            //else
            //{
               var products = _productService.GetById(id);
            //    if (products != null)
            //        _db.StringSetAsync(id.ToString(), JsonSerializer.Serialize(products));
               return Ok(products.Data); //200 + data
            //}
            
            
            
        }
        /// <summary>
        /// Create a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var result=_productService.Add(product);
            if (result.Success)
            {
                return Ok(result.Message); //201 + data
            }
            return BadRequest(result.Message);

        }
        /// <summary>
        /// Update the Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            
            if (_productService.GetById(product.ProductId) != null)
            {
                var result = _productService.Update(product);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            return NotFound();

        }
        /// <summary>
        /// Delete the Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            if (_productService.GetById(id) != null)
            {
                var result= _productService.Delete(id);
                if(result.Success)
                {
                    return Ok(result.Message);
                }
                return NotFound(result.Message);
    
            }
            
            return NotFound("Böyle bir ürün bulunamadı!!!");

        }

    }
}
