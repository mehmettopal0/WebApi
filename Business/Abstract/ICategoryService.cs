using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category entity);
        void Update(Category entity);
        void Delete(int id);
    }
}
