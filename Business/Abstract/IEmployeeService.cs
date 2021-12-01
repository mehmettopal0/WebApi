using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        List<Employee> GetByParent(int id);
        List<Employee> GetAllChildByParent(int id);
        void Add(Employee entity);
        void Update(Employee entity);
        void Delete(int id);
    }
}
