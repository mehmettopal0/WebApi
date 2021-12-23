using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductArea:IEntity
    {
        [ForeignKey("ProductContent")]
        public int ProductContentId { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }

        public ProductContent ProductContent { get; set; }
        public Area Area { get; set; }

    }
}
