using Microsoft.EntityFrameworkCore;
using Semana_16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semana_16.Data
{
    public class Semana_16Context : DbContext
    {
        public Semana_16Context(DbContextOptions<Semana_16Context> options) : base(options)
        {

        }

        public DbSet<Movie> Movie { get; set; }

    }
}
