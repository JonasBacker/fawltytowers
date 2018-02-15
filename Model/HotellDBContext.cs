using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace Model
{
    public class HotellDBContext : DbContext
    {
        public DbSet<Room> Room { get; set; }
        public DbSet<Booking> Booking { get; set; }
      
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Issue> Issue { get; set; }
    }
}
