using API.Redis;
using Business.Abstract;
using Business.Enumarations;
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
        private ICacheService _cacheService;
        public EmployeeManager(IEmployeeDal employeeDal, ICacheService cacheService)
        {
            _employeeDal = employeeDal;
            _cacheService = cacheService;
        }
        public IResult Add(Employee entity)
        {
            _employeeDal.Add(entity);
            _cacheService.Remove(CacheEnum.Employees);
            return  new SuccessResult(); 


            
        }
        public IResult AddTree(Employee entity)
        {
            _employeeDal.AddTree(entity);
            _cacheService.Remove(CacheEnum.Employees);
            return new SuccessResult();
        }

        public void TreeDelete(int id)
        {
            
            _employeeDal.TreeDelete(id);
            _cacheService.Remove(CacheEnum.Employees);
        }

        public List<Employee> GetAll()
        {
            if (_cacheService.Any(CacheEnum.Employees))
            {
                var employee = _cacheService.Get<List<Employee>>(CacheEnum.Employees);
                return employee;
            }
            var employees = _employeeDal.GetAll();
            _cacheService.Add(CacheEnum.Employees, employees);
            return employees;
            
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
            _cacheService.Remove(CacheEnum.Employees);
        }


    }
}
