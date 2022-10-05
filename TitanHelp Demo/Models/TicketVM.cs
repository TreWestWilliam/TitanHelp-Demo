using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TitanHelp_Demo.Models
{
    public class TicketVM // Ticket Virtual Model, what the client submits to the server
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string Title { get; set; } // The Ticket's Title
        public Priority TicketPriority { get; set; } // The Tickets Priortiy
        [Required]
        [StringLength(1000, ErrorMessage = "A Ticket's Content cannot be longer than 1,000 characters.")]
        [Display(Name = "Ticket Content")]
        public string Content { get; set; } // The Ticket's Content (Big block of text)
        public DateTime CurrentDT { get; set; }
    }
}
