using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, WebApiDbContext>, IEmployeeDal
    {
        public IResult AddTree(Employee entity)
        {
            using (WebApiDbContext context = new WebApiDbContext())
            {
                var emptree = context.Employees.FirstOrDefault(x => x.Id == entity.ParentId);
                if (emptree != null || entity.ParentId==0) { 
                if (entity.ParentId >= 0) {
                List<Employee> employee = context.Employees.Where(x => x.ParentId == entity.ParentId).ToList();
                if (employee == null)
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                        return new SuccessResult();
                    }
                else
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                    foreach (var emp in employee)
                    {
                        emp.ParentId = entity.Id;
                    }
                    
                    context.SaveChanges();
                        return new SuccessResult();
                    }
                }
                else
                {
                    return new ErrorResult("ParentId 0'dan küçük olamaz!");
                }
                }
                else
                {
                    return new ErrorResult("Böyle bir ParentId bulunamadı!");
                }
            }
        }

        public List<Employee> GetAllChildByParent(int parentId)
        {
            List<Employee> result = new List<Employee>();
            GetChilds(parentId, result);
            return result;
        }

        private void GetChilds(int parentId, List<Employee> listchild)
        {
            using (WebApiDbContext context = new WebApiDbContext())
            {

                var subchild = context.Employees.Where(p => p.ParentId == parentId).ToList();
                if (subchild.Any())
                {
                    foreach (var sub in subchild)
                    {
                        if (sub.SubChild == null)
                            sub.SubChild = new List<Employee>();

                        GetChilds(sub.Id, sub.SubChild);
                        listchild.Add(sub);
                    }
                }
            }
        }
    }
}
