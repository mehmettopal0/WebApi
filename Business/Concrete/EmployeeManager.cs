using API.Redis;
using AutoMapper;
using Business.Abstract;
using Business.Enumarations;
using Core.Utilities.Results;
using DataAccess;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
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
        private readonly IMapper _mapper;
        private readonly WebApiDbContext _context;

        public EmployeeManager(IEmployeeDal employeeDal, ICacheService cacheService, WebApiDbContext context, IMapper mapper)
        {
            _employeeDal = employeeDal;
            _cacheService = cacheService;
            _context = context;
            _mapper = mapper;

        }
        public int employeeCacheCount;
        public IResult Add(EmployeeRequestDto employeeRequestDto)
        {
            
            var employee = _mapper.Map<Employee>(employeeRequestDto);
            var empl = _context.Employees.FirstOrDefault(e => e.Id == employee.ParentId);
            if (empl != null || employee.ParentId == null)
            {
                _employeeDal.Add(employee);
                _cacheService.Remove(CacheEnum.Employees);
                return new SuccessResult();
            }
            return new ErrorResult();
            

        }
        public IResult AddTree(EmployeeRequestDto employeeRequestDto)
        {
            var employee = _mapper.Map<Employee>(employeeRequestDto);
            _employeeDal.AddTree(employee);
            _cacheService.Remove(CacheEnum.Employees);
            return new SuccessResult();
        }

        public void TreeDelete(int id)
        {

            _employeeDal.TreeDelete(id);
            _cacheService.Remove(CacheEnum.Employees);
        }

        public List<EmployeeDto> GetAll()
        {

            if (_cacheService.Any(CacheEnum.Employees))
            {

                var employee = _cacheService.Get<List<Employee>>(CacheEnum.Employees);
                var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employee);
                return (List<EmployeeDto>) employeesDto;

            }
            var employees = _employeeDal.GetAll();
            var employeesDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            _cacheService.Add(CacheEnum.Employees, employees);
            return (List<EmployeeDto>)employeesDtos;

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

        public void Update(EmployeeUpdateRequestDto employeeUpdateRequestDto)
        {
            var employee = _mapper.Map<Employee>(employeeUpdateRequestDto);
            _employeeDal.Update(employee);
            _cacheService.Remove(CacheEnum.Employees);
        }


    }
}
