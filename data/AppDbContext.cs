using Microsoft.EntityFrameworkCore;
using model;
using System;
using System.Collections.Generic;
using System.Text;

namespace data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pet> pets => Set<Pet>();
        public DbSet<Proprietario> proprietari => Set<Proprietario>();

    }
}
