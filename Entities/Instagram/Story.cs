using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Instagram
{
    public class Story:IEntity
    {
        public int Id { get; set; }

        [ForeignKey("InstagramUser")]
        public int? UserId { get; set; }
        public InstagramUser InstagramUser { get; set; }

        public string PostUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
