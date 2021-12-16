using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEmployeeDal : GenericRepositoryBase<Employee>, IEmployeeDal
    {
        public WebApiDbContext _context { get; set; }
        public EfEmployeeDal(WebApiDbContext context) : base(context)
        {
            _context = context;
        }
        public IResult AddTree(Employee entity)
        {

            List<Employee> employee = _context.Employees.Where(x => x.ParentId == entity.ParentId).ToList();
            var empl = _context.Employees.FirstOrDefault(e => e.Id == entity.ParentId);
            if (empl != null || entity.ParentId == null)
            {

                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
                if (entity.ChildId != null)
                {
                    var emlChild = _context.Employees.FirstOrDefault(em => em.Id == entity.ChildId);
                    emlChild.ParentId = entity.Id;
                }
                else
                {

                    foreach (var emp in employee)
                    {
                        emp.ParentId = entity.Id;
                    }
                }
                _context.SaveChanges();
                return new SuccessResult();
            }
            return new ErrorResult();


        }
        public void TreeDelete(int id)
        {

            Employee empl = _context.Employees.FirstOrDefault(x => x.Id == id);
            List<Employee> employee = _context.Employees.Where(x => x.ParentId == empl.Id).ToList();
            foreach (var emp in employee)
            {
                emp.ParentId = empl.ParentId;
            }
            empl.SubChild = null;
            _context.SaveChanges();
            _context.Set<Employee>().Remove(empl);
            _context.SaveChanges();


        }

        public List<Employee> GetAllChildByParent(int parentId)
        {
            List<Employee> result = new List<Employee>();
            GetChilds(parentId, result);
            return result;
        }



        private void GetChilds(int parentId, ICollection<Employee> listchild)
        {


            var subchild = _context.Employees.Where(p => p.ParentId == parentId).ToList();
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
