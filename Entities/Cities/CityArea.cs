using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CityArea:IEntity
    {
        public int CityAreaId { get; set; }
        public string CityName { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public ICollection<ProductCity> ProductCities { get; set; }


    }
}
