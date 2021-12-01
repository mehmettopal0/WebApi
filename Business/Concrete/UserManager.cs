using Business.Abstract;
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
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User entity)
        {
            _userDal.Add(entity);
        }

        public void Delete(int id)
        {
            _userDal.Delete(id);
        }

        public List<User> GetAll()
        {
            
            return _userDal.GetAll();
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
