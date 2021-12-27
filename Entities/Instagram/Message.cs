using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Instagram
{
    public class Message:IEntity
    {
        public int Id { get; set; }

        [ForeignKey("InstagramUser")]
        public int? SenderId { get; set; }
        public InstagramUser InstagramUser { get; set; }

        [ForeignKey("InstagramUser2")]
        public int? ReceiverId { get; set; }
        public InstagramUser InstagramUser2 { get; set; }

        public string MessageBody { get; set; }
        public DateTime SentDate { get; set; }

    }
}
