using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
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
                   // UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\UserDb.mdf;integrated security=True;MultipleActiveResultSets=True");
                   UseSqlServer(@"Server=tcp:vereslevente.database.windows.net,1433;Initial Catalog=gamehubdb;Persist Security Info=False;User ID=vereslevi;Password=Lalapapa73;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", x => x.MigrationsAssembly("ApiApp"));
            }
        }

        public UserDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<IdentityRole>().HasData(
              new { Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6", Name = "Admin", NormalizedName = "ADMIN" },
              new { Id = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6", Name = "Customer", NormalizedName = "CUSTOMER" }
             );

            var appUser = new IdentityUser
            {
                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "veres.levente@nik.uni-obuda.hu",
                NormalizedEmail = "veres.levente@nik.uni-obuda.hu",
                EmailConfirmed = true,
                UserName = "veres.levente@nik.uni-obuda.hu",
                NormalizedUserName = "veres.levente@nik.uni-obuda.hu",
                SecurityStamp = string.Empty
            };

            var appUser2 = new IdentityUser
            {
                Id = "e2174cf0–9412–4cfe-afbf-59f706d72cf6",
                Email = "veres.levente2@nik.uni-obuda.hu",
                NormalizedEmail = "veres.levente2@nik.uni-obuda.hu",
                EmailConfirmed = true,
                UserName = "veres.levente2@nik.uni-obuda.hu",
                NormalizedUserName = "veres.levente2@nik.uni-obuda.hu",
                SecurityStamp = string.Empty
            };

            appUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Almafa123!");
            appUser2.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Almafa123!");


            modelbuilder.Entity<IdentityUser>().HasData(appUser);
            modelbuilder.Entity<IdentityUser>().HasData(appUser2);

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                UserId = "02174cf0–9412–4cfe-afbf-59f706d72cf6"
            });

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "341743f0-dee2–42de-bbbb-59kmkkmk72cf6",
                UserId = "e2174cf0–9412–4cfe-afbf-59f706d72cf6"
            });



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



        public DbSet<User> Gamers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

    }
}
