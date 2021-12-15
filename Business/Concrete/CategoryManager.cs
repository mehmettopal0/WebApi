using API.Redis;
using Business.Abstract;
using Business.Enumarations;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        private ICacheService _cacheService;
        public int categoryCacheCount = 0;

        public CategoryManager(ICategoryDal categoryDal,ICacheService cacheService )
        {
            _categoryDal = categoryDal;
            _cacheService = cacheService;
        }

        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
            categoryCacheCount++;
            //_cacheService.Remove(CacheEnum.Categories);
        }

        public void Delete(int id)
        {
            _categoryDal.Delete(id);
            categoryCacheCount++;
            //_cacheService.Remove(CacheEnum.Categories);
        }


        public List<Category> GetAll()
        {
            if (_cacheService.Any(CacheEnum.Categories))
            {
                if (categoryCacheCount == 0)
                {
                    var category = _cacheService.Get<List<Category>>(CacheEnum.Categories);
                    return category;
                }
                _cacheService.Remove(CacheEnum.Categories);
                categoryCacheCount = 0;
            }
            var categories = _categoryDal.GetAll();
            _cacheService.Add(CacheEnum.Categories, categories);
            return categories;
            
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
            categoryCacheCount++;
            //_cacheService.Remove(CacheEnum.Categories);
        }

        
    }
}
