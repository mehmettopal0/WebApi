using Business.Abstract;
using Business.Constants;
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
        public ProductManager(IProductDal productDal/*,IConnectionMultiplexer redis*/)
        {
            _productDal = productDal;
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
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(int id)
        {
            var mehmet = _productDal.GetById(id);
            if (mehmet.ProductPrice<5000)
            {
                _productDal.Delete(id);
                return  new SuccessResult(Messages.ProductDeleted);
                

            }
            return new ErrorResult(Messages.ProductNotDeletable);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
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
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
