using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TitanHelp_Demo.Models
{
    public class Ticket_Readable
    {
        public string Title { get; set; } // The Ticket's Title
        public string Content { get; set; } // The Ticket's Content (Big block of text)
        public DateTime CreationDT { get; set; } // The date time the ticket was created
        public string CreatorName { get; set; }
        public Ticket_Readable(Ticket t) 
        {
            Title = t.Title;
            Content = t.Content;
            CreationDT = t.CreationDT;
            CreatorName = "Anonymous";
        }
    }
}
