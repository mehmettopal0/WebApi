using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
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
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
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
            var products = _productService.GetById(id);
            return Ok(products.Data); //200 + data
            
            
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
