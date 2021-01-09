using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bolog_Andreea_Proiect.Models;

namespace Bolog_Andreea_Proiect.Data
{
    public class Bolog_Andreea_ProiectContext : DbContext
    {
        public Bolog_Andreea_ProiectContext (DbContextOptions<Bolog_Andreea_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Bolog_Andreea_Proiect.Models.Movie> Movie { get; set; }

        public DbSet<Bolog_Andreea_Proiect.Models.Publisher> Publisher { get; set; }

        public DbSet<Bolog_Andreea_Proiect.Models.Category> Category { get; set; }
    }
}
