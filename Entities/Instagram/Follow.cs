using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Instagram
{
    public class Follow:IEntity
    {
        public int Id { get; set; }

        [ForeignKey("InstagramUser")]
        public int? FollowerId { get; set; }
        public InstagramUser InstagramUser { get; set; }

        [ForeignKey("InstagramUser2")]
        public int? FollowingId { get; set; }
        public InstagramUser InstagramUser2 { get; set; }


    }
}
