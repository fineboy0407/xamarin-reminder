using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reminder.Data.Entities;

namespace Reminder.Data.EF
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="AppIdentityDbContext"/> class.
        /// </summary>
        /// <param name="dbContextOptions">The database context options.</param>
        /// <param name="schemaName">Name of the schema.</param>
        public AppIdentityDbContext(DbContextOptions dbContextOptions, string schemaName)
            : base(dbContextOptions)
        {
            SchemaName = schemaName;
        }

        /// <summary>
        /// Database schema name
        /// </summary>
        public string SchemaName { get; }

        /// <inheritdoc />
        /// <summary>
        /// Applying the configuration of dbContext entities
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<AchievementModel>("Achievements", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<AchievementNote>("AchievementNotes", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<BirthdayModel>("Birthdays", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<Note>("Notes", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<PhotoModel>("Photos", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<ToDoModel>("ToDoModels", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<VideoModel>("Videos", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<AppUser>("AspNetUsers", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityRole>("AspNetRoles", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityUserClaim<string>>("AspNetUserClaims", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityUserRole<string>>("AspNetUserRoles", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityUserLogin<string>>("AspNetUserLogins", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityRoleClaim<string>>("AspNetRoleClaims", SchemaName));
            modelBuilder.ApplyConfiguration(new AppIdentityTypeConfiguration<IdentityUserToken<string>>("AspNetUserToken", SchemaName));
        }
    }
}