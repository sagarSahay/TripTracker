namespace TripTracker.BackService.Data
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Models;

    public class TripContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public TripContext(DbContextOptions<TripContext> options) : base(options)
        {
            //this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public TripContext()
        {
            
        }

        public TripContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Trip>().HasKey(t => t.Id);
        }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated();

                if (context.Trips.Any()) return;

                context.Trips.AddRange(
                        new Trip
                        {
                            Id = 1,
                            Name = "MVP Summit",
                            StartDate = new DateTime(2018, 8, 5),
                            EndDate = new DateTime(2018, 8, 8)
                        },
                        new Trip
                        {
                            Id = 2,
                            Name = "DevIntersection Orlando",
                            StartDate = new DateTime(2018, 8, 23),
                            EndDate = new DateTime(2018, 2, 25)
                        },
                        new Trip
                        {
                            Id = 3,
                            Name = "Build 2018",
                            StartDate = new DateTime(2018, 9, 2),
                            EndDate = new DateTime(2018, 9, 8)
                        }
                    );
                context.SaveChanges();

            }
        }
    }
}
