using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly WebApiDbContext _context;
        public GenericRepositoryBase(WebApiDbContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#

            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();

        }

        public void Delete(int id)
        {

            var deletedEntity = GetById(id);
            _context.Set<TEntity>().Remove(deletedEntity);
            _context.SaveChanges();

        }



        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();

        }


        public TEntity GetById(int id)
        {

            return _context.Set<TEntity>().Find(id);

        }

        public void Update(TEntity entity)
        {

            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
