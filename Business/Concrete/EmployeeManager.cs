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
        //private WebApiDbContext _context;
        private readonly WebApiDbContext _context;
        
        public EmployeeManager(IEmployeeDal employeeDal, ICacheService cacheService, WebApiDbContext context)
        {
            _employeeDal = employeeDal;
            _cacheService = cacheService;
            _context = context;
            
        }
        public int employeeCacheCount;
        public IResult Add(Employee entity)
        {
            //using (WebApiDbContext context=new WebApiDbContext())
            //{
                var empl = _context.Employees.FirstOrDefault(e => e.Id == entity.ParentId);
                if (empl != null || entity.ParentId == null)
                {
                    _employeeDal.Add(entity);
                    employeeCacheCount++;
                    _cacheService.Remove(CacheEnum.Employees);
                    return new SuccessResult();
                }
                return new ErrorResult();
            //}
            
                


            
        }
        public IResult AddTree(Employee entity)
        {
            _employeeDal.AddTree(entity);
            employeeCacheCount++;
            _cacheService.Remove(CacheEnum.Employees);
            return new SuccessResult();
        }

        public void TreeDelete(int id)
        {
            
            _employeeDal.TreeDelete(id);
            employeeCacheCount++;
            _cacheService.Remove(CacheEnum.Employees);
        }

        public List<Employee> GetAll()
        {
            var count = employeeCacheCount;
            if (_cacheService.Any(CacheEnum.Employees))
            {
                if (count == 0)
                {
                    var employee = _cacheService.Get<List<Employee>>(CacheEnum.Employees);
                    return employee;
                }
                _cacheService.Remove(CacheEnum.Employees);
                employeeCacheCount = 0;
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
            employeeCacheCount++;
            _cacheService.Remove(CacheEnum.Employees);
        }


    }
}
