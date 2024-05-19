using AutoChef.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoChef.Data
{
    public class ApplicationDbContext : DbContext
    { 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }



        public DbSet<OrderModel> Order { get; set; }

        public DbSet<RestaurantModel> Restaurant { get; set; }

        public DbSet<UserModel> User { get; set; }

    }
}
