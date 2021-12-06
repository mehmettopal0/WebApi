using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees); //200 + data
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
            var result = _employeeService.GetAllChildByParent(id);
            return Ok(result);
        }

        /// <summary>
        /// Create an Employees
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            _employeeService.Add(employee);
            return Ok("Ekleme işlemi başarılı...Eklenen kişi: " + employee.Name); //201 + data

        }
        /// <summary>
        /// Create an Employees
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost("addtree")]
        public IActionResult PostEmployeeTree([FromBody] Employee employee)
        {
            _employeeService.AddTree(employee);
            return Ok("Ekleme işlemi başarılı...Eklenen kişi: " + employee.Name); //201 + data

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
                return Ok(employee.Name + " adlı kullanıcının bilgileri başarılı bir şekilde güncellendi.");
            }
            return NotFound("Başarısız!!!!");

        }
        /// <summary>
        /// Delete the Employee
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_employeeService.GetById(id) != null)
            {
                _employeeService.Delete(id);
                return Ok("Kişi silme işlemi başarılı..");
            }
            return NotFound("Böyle bir kişi bulunamadı!!!");

        }
    }
}
