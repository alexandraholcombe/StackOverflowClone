using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOverflow.Models;

namespace StackOverflow.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public DbSet<Question> Questions { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //public override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StackOverflow;integrated security=True");
        //}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
       
    }
}
