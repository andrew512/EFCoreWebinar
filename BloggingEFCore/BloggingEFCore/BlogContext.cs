using BloggingEFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Console;

namespace BloggingCoew
{
    public class BlogContext : DbContext
    {
        public static readonly LoggerFactory ConsoleLoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((cat, level) => cat == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information, true) });

        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(e =>
                {
                    e.Property(a => a.Surname).IsRequired();
                });

            modelBuilder.Entity<PostAuthorLink>(e =>
            {
                e.HasKey(l => new { l.AuthorId, l.PostId });
            });

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=.;Initial Catalog=BloggingEFCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging()
                .UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
