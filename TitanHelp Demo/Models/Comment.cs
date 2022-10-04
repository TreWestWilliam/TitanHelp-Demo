using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TitanHelp_Demo.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
        public DateTime CreationDT { get; set; }
        public int TicketId { get; set; }
    }
}
