using System;
using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore;
using personalProjectAPI.Domains;

namespace personalProjectAPI.Db
{
    public class PersonalProjectDbContext : DbContext
    {
        public PersonalProjectDbContext(DbContextOptions<PersonalProjectDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
    }
}