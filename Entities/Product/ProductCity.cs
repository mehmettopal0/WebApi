using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductCity:IEntity
    {

        [ForeignKey("ProductContent")]
        public int ProductContentId { get; set; }

        [ForeignKey("CityArea")]
        public int CityAreaId { get; set; }

        public ProductContent ProductContent { get; set; }
        public CityArea CityArea { get; set; }
    }
}
