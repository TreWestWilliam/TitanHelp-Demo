using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TitanHelp_Demo.Models
{
    public class User
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public string ScreenName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
