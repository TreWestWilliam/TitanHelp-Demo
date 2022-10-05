using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanHelp_Demo.Models;

namespace TitanHelp_Demo.Data
{
    public class DbInitializer
    {
        public static void Initialize(TicketsContext context) 
        {
            context.Database.EnsureCreated();
            //Look if we have any users
            if (context.Users.Any()) 
            {
                return; // The Database has been seeded in this case
                // Return to escape
            }

            var Users = new User[]
            {
                //new User{}
                new User{ScreenName = "User1", Password="pword"},
                new User{ScreenName = "Player2", Password="pword"},
                new User{ScreenName = "Mister3", Password="pword"},
                new User{ScreenName = "Misses4", Password="pword"}
            };

            context.Users.AddRange(Users);
            context.SaveChanges();

            var Tickets = new Ticket[] 
            { /*
                new Ticket{Title="Ticket 1", TicketPriority = Priority.normal, Content = "This is a ticket.", CreationDT = DateTime.Now, CreatorId = 0, IsOpen = true},
                new Ticket{Title="Ticket 2", TicketPriority = Priority.high, Content = "This is another ticket.", CreationDT = DateTime.Today, CreatorId = 1, IsOpen = true},
                new Ticket{Title="Third Ticket", TicketPriority = Priority.low, Content = "This is yet another ticket.  This one is made in the future.", CreationDT = DateTime.Today.AddDays(1), CreatorId = 2, IsOpen = true},
                new Ticket{Title="Fourth Ticket", TicketPriority = Priority.high, Content = "This is a closed ticket.", CreationDT = DateTime.Now.AddDays(-1), CreatorId = 1, IsOpen = false}
            */};

            context.Tickets.AddRange(Tickets);
            context.SaveChanges();

            var Comments = new Comment[] 
            { 
                new Comment{UserID=1, Content="This is a comment",CreationDT = DateTime.Now, TicketId = 0},
                new Comment{UserID=1, Content="This is another comment",CreationDT = DateTime.Now, TicketId = 1}
            };

            context.Comments.AddRange(Comments);
            context.SaveChanges();
 

        }
    }
}
