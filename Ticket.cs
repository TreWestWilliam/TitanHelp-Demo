using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace TitanHelp_Demo.Models
{
    public class EditForm : Microsoft.AspNetCore.Components.ComponentBase { }
    public class Ticket
    {
        public string title;

        [Required]
        [StringLength(50, ErrorMessage = "Name too long (50 character limit).")]
        public string FullName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime TDate { get; set; }

        public int UID;
    }
}