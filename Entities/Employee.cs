using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? ChildId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Employee Parent { get; set; }
        public virtual ICollection<Employee> SubChild { get; set; }
        

    }
}
