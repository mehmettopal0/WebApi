using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfProductDal : GenericRepositoryBase<Product>, IProductDal
    {
        public WebApiDbContext _context { get; set; }
        public EfProductDal(WebApiDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
