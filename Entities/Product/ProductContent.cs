using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductContent:IEntity
    {
        public int ProductContentId { get; set; }
        public int Price { get; set; }

        public ICollection<ProductArea> ProductAreas { get; set; }
        public ICollection<ProductCity> ProductCities { get; set; }
    }
}
