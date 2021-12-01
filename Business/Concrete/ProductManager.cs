using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
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
            return new SuccessDataResult<Product>(_productDal.GetById(id));
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
