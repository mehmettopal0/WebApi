using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Instagram
{
    public class InstagramUser:IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public string Email { get; set; }
        public string ProfileDescription { get; set; }
        public DateTime CreateDate { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Story> Stories { get; set; }


    }
}
