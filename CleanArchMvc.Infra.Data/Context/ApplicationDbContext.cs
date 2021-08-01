using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; set; } //Mapping ORM Class Category to Table Categories

        public DbSet<Product> Products { get; set; } //Mapping ORM Class Product to table Products

        protected override void OnModelCreating(ModelBuilder builder) //Configuring Model using Fluent API
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // builder.ApplyConfiguration(new CategoryConfiguration());
            // dont need because we use ApplyConfigurationsFromAssembly


        }
    }
}
