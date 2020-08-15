using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoTaskApps.Entities;

namespace ToDoTaskApps.DBContext
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext>options) :
            base(options)
        {

        }

        public DbSet<Todo> Todos {get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(new Todo()
            {
                Id = Guid.Parse("00A1"),
                Expiry = new DateTime(2020, 9, 9),
                Title = "Learn A code",
                Description = "watch a tutorial and learn",
                Complete = 40
            },
                new Todo
                {
                    Id = Guid.Parse("00A2"),
                    Expiry = new DateTime(2020, 10, 9),
                    Title = "Cleaning a house",
                    Description = "cleaning a house",
                    Complete = 20

                })
                ;
        }
    }
}
