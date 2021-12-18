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
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        private ICacheService _cacheService;
        public int userCacheCount = 0;
        public UserManager(IUserDal userDal, ICacheService cacheService)
        {
            _userDal = userDal;
            _cacheService = cacheService;
        }
        public void Add(User entity)
        {
            _userDal.Add(entity);
            userCacheCount++;
            _cacheService.Remove(CacheEnum.Users);
        }

        public void Delete(int id)
        {
            _userDal.Delete(id);
            userCacheCount++;
            _cacheService.Remove(CacheEnum.Users);
        }

        public List<User> GetAll()
        {
            if (_cacheService.Any(CacheEnum.Users))
            {
                if (userCacheCount == 0)
                {
                    var user = _cacheService.Get<List<User>>(CacheEnum.Users);
                    return user;
                }
                
            }
            var users = _userDal.GetAll();
            _cacheService.Add(CacheEnum.Users, users);
            return users;
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
            userCacheCount++;
            _cacheService.Remove(CacheEnum.Users);
        }
    }
}
