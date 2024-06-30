using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetCenter.Domain.Model;
using PetCenter.Domain.State;

namespace PetCenter.Repository
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostState>(entity =>
            {
                entity.ToTable("postStates");
                entity.HasDiscriminator<string>("StateType")
                    .HasValue<Accepted>("Accepted")
                    .HasValue<Adopted>("Adopted")
                    .HasValue<Created>("Created")
                    .HasValue<Declined>("Declined")
                    .HasValue<Hidden>("Hidden")
                    .HasValue<OnHold>("OnHold")
                    .HasValue<TemporaryAccommodation>("TemporaryAccommodation");
            });

            modelBuilder.Entity<Post>()
                .HasOne(p => p.State)
                .WithOne()
                .HasForeignKey<PostState>(s => s.Id);

            modelBuilder.Entity<Account>()
                .HasIndex(account => account.Email)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(account => account.Username)
                .IsUnique();

            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=PetCenter;Username=postgres;Password=1234;");
            }
        }
    }
}
