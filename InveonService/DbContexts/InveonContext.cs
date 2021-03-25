using InveonService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InveonService.DbContexts
{
    public class InveonContext : DbContext
    {
        public InveonContext(DbContextOptions<InveonContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "admin",
                    UserType = "admin",
                },
                new User
                {
                    Id = 2,
                    UserName = "user",
                    Password = "user",
                    UserType = "user",
                }
                );


        }


    }
}
