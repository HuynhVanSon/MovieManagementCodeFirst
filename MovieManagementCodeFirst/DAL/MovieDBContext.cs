using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MovieManagementCodeFirst.Models;

namespace MovieManagementCodeFirst.DAL
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext()
        {

        }

        public DbSet<Film> Films { get; set; }

        public DbSet<FilmType> FilmTypes { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TicketType> TicketTypes { get; set; }
    }
}