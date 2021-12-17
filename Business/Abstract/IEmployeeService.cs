using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAll();
        Employee GetById(int id);
        List<Employee> GetByParent(int id);
        List<Employee> GetAllChildByParent(int id);
        IResult Add(EmployeeRequestDto employeeRequestDto);
        IResult AddTree(EmployeeRequestDto employeeRequestDto);
        void Update(EmployeeUpdateRequestDto employeeUpdateRequestDto);
        void TreeDelete(int id);
    }
}
