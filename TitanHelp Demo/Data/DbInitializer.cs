using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanHelp_Demo.Models;

namespace TitanHelp_Demo.Data
{
    public class DbInitializer
    {
        public static void Initialize(TicketContext context) 
        {

            //Look if we have any users
            if (context.Users.Any()) 
            {
                return; // The Database has been seeded in this case
                // Return to escape
            }

            var Users = new User[]
            {
                //new User{}
            };

            context.Users.AddRange(Users);
            context.SaveChanges();

            var Tickets = new Ticket[] { };

            context.Tickets.AddRange(Tickets);
            context.SaveChanges();

            var Comments = new Comment[] { };

            context.Comments.AddRange(Comments);
            context.SaveChanges();
 

        }
    }
}
