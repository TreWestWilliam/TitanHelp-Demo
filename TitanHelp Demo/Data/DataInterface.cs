using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitanHelp_Demo.Models;

namespace TitanHelp_Demo.Data
{
    public class DataInterface
    {
        public static void CreateTicket(TicketsContext _context, TicketVM testTicket, int UID) 
        {
            testTicket.TicketPriority = Priority.normal; // Ticket priority isnt implemented, we're basically not worrying about it.

            Ticket ticket = new Ticket // We create a new ticket since we're using Ticket VM
            {
                Title = testTicket.Title, // We're basically just throwing the valid input from test ticket into here
                Content = testTicket.Content,
                TicketPriority = testTicket.TicketPriority,
                CreationDT = testTicket.CurrentDT,
                CreatorId = UID, // We get the cookie of the username since we doont store user id, and then look up the uid
                IsOpen = true // Opening isnt implemented, dont worry about it.
            };

            _context.Tickets.Add(ticket); // Here we're telling Entity Framework we want to upload the ticket to the database
            _context.SaveChanges(); // Telling entity framework to save all changes to the database.
        }

        public static string UserIdToName(TicketsContext _context, int UID) 
        {
            foreach (User u in _context.Users)
            {
                if (u.UserID == UID)
                    return u.ScreenName;
            }
            return "Anonymous"; // And if that doesn't work we'll just call them anonymous since we probably defaulted to id 0 from the creation page.
        }
        public static string UserIdToName(IEnumerable<User> users, int UID)
        {
            foreach (User u in users)
            {
                if (u.UserID == UID)
                    return u.ScreenName;
            }
            return "Anonymous"; // And if that doesn't work we'll just call them anonymous since we probably defaulted to id 0 from the creation page.
        }

        public static List<Ticket_Readable> AllTickets(TicketsContext _context)
        {
            List<Ticket_Readable> tickets = new List<Ticket_Readable>();
            foreach (Ticket t in _context.Tickets)
            {
                Ticket_Readable TR = new Ticket_Readable(t)
                {
                    CreatorName = UserIdToName(_context, t.CreatorId)
                };
                tickets.Add(TR);
            }
            return tickets;
        }

    }
}
