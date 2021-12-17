using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Product:IEntity
    {
        [Key]
        public int ProductId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        
        [MaxLength(500)]
        public string ProductDetail { get; set; }
        [Required]
        public double ProductPrice { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
