﻿using API.Redis;
using AutoMapper;
using Business.Abstract;
using Entities;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        //private readonly IDistributedCache _distributedCache;
        //private ICacheService _cacheService;
        public EmployeesController(IEmployeeService employeeService,IMapper mapper /*,ICacheService cacheService IDistributedCache distributedCache*/)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            //_distributedCache = distributedCache;
            //_cacheService = cacheService;
        }
        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            //if (_cacheService.Any("employees") )
            //{
            //    var employee = _cacheService.Get<List<Employee>>("employees");
            //    return Ok(employee);
            //}
            var employees = _employeeService.GetAll();
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            //_cacheService.Add("employees", employees);

            return Ok(employeesDto);
        }
        
        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employees = _employeeService.GetById(id);
            return Ok(employees); //200 + data
        }
        /// <summary>
        /// getbyparent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getbyparent")]
        public IActionResult GetByParent(int id)
        {
            var result = _employeeService.GetByParent(id);
            return Ok(result);
        }
        /// <summary>
        /// getbyparent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getallchildbyparent")]
        public IActionResult GetAllChildByParent(int id)
        {
            //if (_cacheService.Any("employees"))
            //{
            //    var user = _cacheService.Get<List<User>>("employees");
            //    return Ok(user);
            //}
            //var employees = _employeeService.GetAllChildByParent(id);
            //_cacheService.Add("employees", employees);

            //return Ok(employees); //200 + data
            //var cacheKey = "getallchildbyparent";
            //string serializedEmployeeList;
            //var employees = new List<Employee>();
            //var redisEmployeeList = _distributedCache.Get(cacheKey);
            //if (redisEmployeeList != null)
            //{
            //    serializedEmployeeList = Encoding.UTF8.GetString(redisEmployeeList);
            //    employees = JsonConvert.DeserializeObject<List<Employee>>(serializedEmployeeList);
            //}
            //else
            //{
            //    employees = _employeeService.GetAllChildByParent(id);
            //    serializedEmployeeList = JsonConvert.SerializeObject(employees);
            //    redisEmployeeList = Encoding.UTF8.GetBytes(serializedEmployeeList);
            //    var options = new DistributedCacheEntryOptions()
            //        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
            //        .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            //    _distributedCache.SetAsync(cacheKey, redisEmployeeList, options);
            //}
            //return Ok(employees);
            var result = _employeeService.GetAllChildByParent(id);
            return Ok(result);
        }

        /// <summary>
        /// Create an Employees
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeRequestDto employeeRequestDto)
        {
            var employee = _mapper.Map<Employee>(employeeRequestDto);
            var result = _employeeService.Add(employee);
            //_cacheService.Remove("employees");
            return Ok(result); //201 + data
        }
        /// <summary>
        /// Create an Employees
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost("addtree")]
        public IActionResult PostEmployeeTree([FromBody] EmployeeRequestDto employeeRequestDto)
        {
            var employee = _mapper.Map<Employee>(employeeRequestDto);
            var result=_employeeService.AddTree(employee);
           // _cacheService.Remove("employees");
            return Ok(result); //201 + data

        }
            /// <summary>
            /// Update the Employee
            /// </summary>
            /// <param name="employee"></param>
            /// <returns></returns>
            [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            if (_employeeService.GetById(employee.Id) != null)
            {
                _employeeService.Update(employee);
               // _cacheService.Remove("employees");
                return Ok(employee.Name + " adlı kullanıcının bilgileri başarılı bir şekilde güncellendi.");
            }
            return NotFound("Başarısız!!!!");

        }
        /// <summary>
        /// Delete the Employee
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult TreeDelete(int id)
        {
            if (_employeeService.GetById(id) != null)
            {
                _employeeService.TreeDelete(id);
                //_cacheService.Remove("employees");
                return Ok("Kişi silme işlemi başarılı..");
            }
            return NotFound("Böyle bir kişi bulunamadı!!!");

        }
    }
}
