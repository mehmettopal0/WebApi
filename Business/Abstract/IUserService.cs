using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User entity);
        void Update(User entity);
        void Delete(int id);
    }
}
