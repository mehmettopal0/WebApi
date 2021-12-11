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
                var empl = context.Employees.FirstOrDefault(e => e.Id == entity.ParentId);
                if (empl != null || entity.ParentId==null)
                {
                    List<Employee> employee = context.Employees.Where(x => x.ParentId == entity.ParentId).ToList();
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
                return new ErrorResult();
               
            }
        }
        public void TreeDelete(int id)
        {
            using (WebApiDbContext context = new WebApiDbContext())
            {
                Employee empl = context.Employees.FirstOrDefault(x => x.Id == id);
                List<Employee> employee = context.Employees.Where(x => x.ParentId == empl.Id).ToList();
                foreach (var emp in employee)
                {
                    emp.ParentId = empl.ParentId;
                }
                empl.SubChild = null;
                context.SaveChanges();
                context.Set<Employee>().Remove(empl);
                context.SaveChanges();

            }
        }

        public List<Employee> GetAllChildByParent(int parentId)
        {
            List<Employee> result = new List<Employee>();
            GetChilds(parentId, result);
            return result;
        }

       

        private void GetChilds(int parentId, ICollection<Employee> listchild)
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
