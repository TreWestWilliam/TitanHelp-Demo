using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TitanHelp_Demo.Models
{

    public enum Priority 
    { 
        low, normal, high, highest
    }
    public class Ticket
    {
        public int Id { get; set; }// ID's are managed by the database/EF we don't set them
        [Required]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string Title { get; set; } // The Ticket's Title
        public Priority TicketPriority { get; set; } // The Tickets Priortiy
        [Required]
        [StringLength(1000, ErrorMessage = "A Ticket's Content cannot be longer than 1,000 characters.")]
        [Display(Name = "Ticket Content")]
        public string Content { get; set; } // The Ticket's Content (Big block of text)
        [Required]
        public DateTime CreationDT { get; set; } // The date time the ticket was created
        [Required]
        public int CreatorId { get; set; } // The Creator's ID
        [Required]
        public bool IsOpen { get; set; } //Whether the ticket is open or not
        public ICollection<Comment> Comments { get; set; } // Comments related to the ticket, probably wont use.
    }
}
