using Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class EmployeeRequestDto:IDto
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? ChildId { get; set; }
    }
}
