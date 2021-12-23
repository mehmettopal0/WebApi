using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductCom : IEntity
    {
        public int ProductComId { get; set; }

        [ForeignKey("ProductContent")]
        public int ProductContentId { get; set; }
        public ProductContent ProductContent { get; set; }

        public string ProductNameForeignLan { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public string Description { get; set; }
    }
    }
