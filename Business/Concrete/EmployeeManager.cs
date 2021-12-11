using Business.Abstract;
using Core.Utilities.Results;
using DataAccess;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public IResult Add(Employee entity)
        {
            _employeeDal.Add(entity);
            return  new SuccessResult(); 


            
        }
        public IResult AddTree(Employee entity)
        {
            return _employeeDal.AddTree(entity);
        }

        public void TreeDelete(int id)
        {
            _employeeDal.TreeDelete(id);
        }

        public List<Employee> GetAll()
        {

            return _employeeDal.GetAll();
            
        }

        public List<Employee> GetAllChildByParent(int id)
        {
            return _employeeDal.GetAllChildByParent(id);
        }

        public Employee GetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public List<Employee> GetByParent(int id)
        {
            return _employeeDal.GetAll(p => p.ParentId == id);
        }

        public void Update(Employee entity)
        {
            _employeeDal.Update(entity);
        }

        
    }
}
