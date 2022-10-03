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
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        public Priority TicketPriority { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "A Ticket's Content cannot be longer than 1,000 characters.")]
        [Display(Name = "Ticket Content")]
        public string Content { get; set; }
        [Required]
        public DateTime CreationDT { get; set; }
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public bool IsOpen { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
