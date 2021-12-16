using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCategoryDal : GenericRepositoryBase<Category>, ICategoryDal
    {
        public WebApiDbContext _context { get; set; }
        public EfCategoryDal(WebApiDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
