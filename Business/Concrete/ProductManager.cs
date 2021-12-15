using API.Redis;
using Business.Abstract;
using Business.Constants;
using Business.Enumarations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        //private IConnectionMultiplexer _redis;
        //private IDatabase _db;
        private ICacheService _cacheService;
        public int productCacheCount = 0;
        public ProductManager(IProductDal productDal, ICacheService cacheService/*,IConnectionMultiplexer redis*/)
        {
            _productDal = productDal;
            _cacheService = cacheService;
            //_redis = redis;
            //_db = _redis.GetDatabase();
        }
        
        public IResult Add(Product entity)
        {
            if (entity.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(entity);
            productCacheCount++;
            //_cacheService.Remove(CacheEnum.Products);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(int id)
        {
                _productDal.Delete(id);
                productCacheCount++;
                //_cacheService.Remove(CacheEnum.Products);
                return  new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (_cacheService.Any(CacheEnum.Products))
            {
                if (productCacheCount == 0)
                {
                    var product = _cacheService.Get<List<Product>>(CacheEnum.Products);
                    return new SuccessDataResult<List<Product>>(product, Messages.ProductsListed);
                }
                _cacheService.Remove(CacheEnum.Products);
                productCacheCount = 0;
            }
            var products = _productDal.GetAll();
            _cacheService.Add(CacheEnum.Products, products);
            return new SuccessDataResult<List<Product>>(products, Messages.ProductsListed);
        }

        
        public IDataResult<List<Product>> GetAllByCategoryName(int id)
        {
            
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int id)
        {
            //var cachedId = _db.StringGet(id.ToString());
            //if (cachedId.HasValue)
            //{
            //    return (IDataResult<Product>)JsonSerializer.Deserialize<Product>(cachedId);
            //}
            //else
            //{
                var products = _productDal.GetById(id);
            //    if (products != null)
            //        _db.StringSetAsync(id.ToString(), JsonSerializer.Serialize(products));
                return new SuccessDataResult<Product>(products); //200 + data
            //}                                                              //}

        }

        public IResult Update(Product entity)
        {
            if (entity.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Update(entity);
            productCacheCount++;
            //_cacheService.Remove(CacheEnum.Products);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
