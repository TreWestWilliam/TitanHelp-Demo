using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TitanHelp_Demo.Data;
using TitanHelp_Demo.Models;

namespace TitanHelp_Demo.Pages
{
    public class Test2Model : PageModel
    {
        private readonly TitanHelp_Demo.Data.TicketsContext _context;

        public Test2Model(TitanHelp_Demo.Data.TicketsContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; }

        public async Task OnGetAsync()
        {
            Ticket = await _context.Tickets.ToListAsync();
        }
    }
}
