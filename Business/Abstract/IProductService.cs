using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryName(int id);
        IDataResult<Product> GetById(int id);
        IResult Add(Product entity);
        IResult Update(Product entity);
        IResult Delete(int id);
    }
}
