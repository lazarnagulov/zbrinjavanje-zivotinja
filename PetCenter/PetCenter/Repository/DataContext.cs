using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetCenter.Core.Util;
using PetCenter.Domain.Model;
using PetCenter.Domain.State;

namespace PetCenter.Repository
{
    public class DataContext : DbContext
    {
        private readonly DatabaseCredentials _credentials;
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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildAccount(modelBuilder);
            BuildRequest(modelBuilder);
            BuildPost(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddUserSecrets<App>()
                    .Build();
                var databaseCredentials =
                    new DatabaseCredentials(
                        config["Database:Host"] ?? string.Empty,
                        int.Parse(config["Database:Port"] ?? string.Empty),
                        config["Database:Username"] ?? string.Empty,
                        config["Database:Password"] ?? string.Empty,
                        config["Database:DatabaseName"] ?? string.Empty
                    );
                optionsBuilder.UseNpgsql(databaseCredentials.ConnectionString);
            }
        }

        private static void BuildAccount(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                .HasIndex(account => account.Email)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasIndex(account => account.Username)
                .IsUnique();

        }

        private static void BuildRequest(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasMany(r => r.Voters)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "vote",
                    r => r.HasOne<Person>().WithMany().HasForeignKey("person_id_voter"),
                    p => p.HasOne<Request>().WithMany().HasForeignKey("request_id_voted"),
                    joinEntity =>
                    {
                        joinEntity.HasKey("person_id_voter", "request_id_voted");
                        joinEntity.Property<bool>("voted_for");
                    });
        }

       
        private static void BuildPost(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PostState>(entity =>
            {
                entity.ToTable("post_state");
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

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Offers)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "post_offers",
                    po => po.HasOne<Offer>().WithMany().HasForeignKey("offer_id_offer"),
                    po => po.HasOne<Post>().WithMany().HasForeignKey("post_id_post"),
                    joinEntity =>
                    {
                        joinEntity.HasKey("offer_id_offer", "post_id_post");
                    });

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Likes)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "post_likes",
                    pl => pl.HasOne<Person>().WithMany().HasForeignKey("person_id_liked"),
                    pl => pl.HasOne<Post>().WithMany().HasForeignKey("post_id_liked"),
                    joinEntity =>
                    {
                        joinEntity.HasKey("person_id_liked", "post_id_liked");
                    });

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "post_comments",
                    pc => pc.HasOne<Comment>().WithMany().HasForeignKey("comment_id_comment"),
                    pc => pc.HasOne<Post>().WithMany().HasForeignKey("post_id_post_cmt"),
                    joinEntity =>
                    {
                        joinEntity.HasKey("comment_id_comment", "post_id_post_cmt");
                    });
        }
    }
}
