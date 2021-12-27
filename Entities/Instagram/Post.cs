using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Instagram
{
    public class Post:IEntity
    {
        public int Id { get; set; }

        [ForeignKey("InstagramUser")]
        public int? UserId { get; set; }
        public InstagramUser InstagramUser { get; set; }


        [ForeignKey("PostType")]
        public int? TypeId { get; set; }
        public PostType PostType { get; set; }

        public string PostUrl { get; set; }
        public string PostDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
