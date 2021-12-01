using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, WebApiDbContext>, IEmployeeDal
    {
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
                        if (!listchild.Contains(sub))
                            listchild.Add(sub);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
