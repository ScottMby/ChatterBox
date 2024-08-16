using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Serilog;
using System.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ChatterBox.Models
{
    

    public class ChatterBoxDbContext : DbContext
    {
        public ChatterBoxDbContext(DbContextOptions<ChatterBoxDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Request> Requests { get; set; }

        public DbSet<Chat> Chats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
             .HasMany(u => u.Friends)
             .WithMany()
             .UsingEntity(j => j.ToTable("UserFriends"));

            modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany(u => u.Messages)
            .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<Message>()
            .HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId);

            modelBuilder.Entity<Chat>()
            .HasMany(c => c.Users)
            .WithMany(u => u.Chats)
            .UsingEntity(j => j.ToTable("UserChats"));

        }


    }

    public class ChatterBoxContextFactory: IDesignTimeDbContextFactory<ChatterBoxDbContext>
    {
        public ChatterBoxDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("db-config.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ChatterBoxDbContext>();
            optionsBuilder.UseNpgsql(_configuration.GetValue<string>("ConnectionString"));

            return new ChatterBoxDbContext(optionsBuilder.Options);
        }
    }
}
