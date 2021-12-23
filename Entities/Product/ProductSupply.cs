using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class ProductSupply : IEntity 
    {
        public int ProductSupplyId { get; set; }

        [ForeignKey("ProductContent")]
        public int ProductContentId { get; set; }
        public ProductContent ProductContent { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int StockQuantity { get; set; }

    }
}
