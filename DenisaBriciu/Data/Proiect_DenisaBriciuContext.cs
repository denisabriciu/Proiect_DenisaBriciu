using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_DenisaBriciu.Models;

namespace Proiect_DenisaBriciu.Data
{
    public class Proiect_DenisaBriciuContext : DbContext
    {
        public Proiect_DenisaBriciuContext (DbContextOptions<Proiect_DenisaBriciuContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_DenisaBriciu.Models.Car> Car { get; set; } = default!;

        public DbSet<Proiect_DenisaBriciu.Models.Brand> Brand { get; set; }
    }
}
