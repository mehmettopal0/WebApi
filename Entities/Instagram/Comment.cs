using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Instagram
{
    public class Comment:IEntity
    {
        public int Id { get; set; }

        [ForeignKey("InstagramUser")]
        public int? UserId { get; set; }
        public InstagramUser InstagramUser { get; set; }

        [ForeignKey("Post")]
        public int? PostId { get; set; }
        public Post Post { get; set; }

        public int? CommentId { get; set; }

        public string CommentLine { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment Parent { get; set; }
        public virtual ICollection<Comment> SubComments { get; set; }

        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}
