
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Area:IEntity
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        
        public ICollection<CityArea> CityAreas { get; set; }
        public ICollection<ProductArea> ProductAreas { get; set; }
    }
}
