using Microsoft.EntityFrameworkCore;
using uNews.Models.Entities;

namespace uNews.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<SavedNews> SavedNews { get; set; }

        public DbSet<Role> Roles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region SavedNews

            builder.Entity<SavedNews>()
                .Property(p => p.Title)
                .IsRequired();

            builder.Entity<SavedNews>()
                .Property(p => p.Link)
                .IsRequired();

            builder.Entity<SavedNews>()
                .Property(p => p.Category)
                .IsRequired();

            builder.Entity<SavedNews>()
                .Property(p => p.PublicationDate)
                .IsRequired();

            #endregion

            #region User

            builder.Entity<User>()
                 .Property(p => p.IsLocked)
                 .HasDefaultValue(false);

            builder.Entity<User>()
                .Property(p => p.Email)
                .IsRequired();

            builder.Entity<User>()
                .Property(p => p.Password)
                .IsRequired();

            #endregion

            builder.Entity<User>()
                .HasMany(n => n.SavedNews)
                .WithOne(u => u.User)
                .HasForeignKey(k => k.UserId)
                .HasConstraintName("FK_User_SavedNews")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
