using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Data
{
    public class CheeseDBContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }

        public CheeseDBContext(DbContextOptions<CheeseDBContext> options)
        : base(options)
        { }
    }

}
