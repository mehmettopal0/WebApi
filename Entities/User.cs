using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User:IEntity

    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }
    }
}
