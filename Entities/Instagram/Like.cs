using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Instagram
{
    public class Like:IEntity
    {
        public int Id { get; set; }

        [ForeignKey("InstagramUser")]
        public int? UserId { get; set; }
        public InstagramUser InstagramUser { get; set; }

        [ForeignKey("Post")]
        public int? PostId { get; set; }
        public Post Post { get; set; }

    }
}
