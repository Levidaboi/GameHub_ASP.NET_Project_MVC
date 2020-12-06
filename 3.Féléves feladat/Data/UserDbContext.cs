using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Data
{
    public class UserDbContext : DbContext
    {
       
        public UserDbContext(DbContextOptions<UserDbContext> opt) : base(opt)
        {

        }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\UserDb.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }

        public UserDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Achievement>(entity =>
            {
                entity
                .HasOne(Achievement => Achievement.Game)
                .WithMany(Game => Game.Achievements)
                .HasForeignKey(Achievement =>Achievement.GameId)
                .OnDelete(DeleteBehavior.Cascade);
            });



            modelbuilder.Entity<Game>(entity =>
            {
                entity
                .HasOne(Game => Game.User)
                .WithMany(User => User.GameLibrary)
                .HasForeignKey(Game => Game.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

    }
}
