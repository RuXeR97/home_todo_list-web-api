using Home_todo_list___infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Home_todo_list___infrastructure.Other
{
    public class HomeTodoListDbContext : DbContext
    {
        public static string ConnectionString;
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectRight> ProjectRights { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(@"connectionstring;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectAuthor>()
                .HasKey(bc => new { bc.ProjectId, bc.UserId });
            modelBuilder.Entity<UserProjectRight>()
                .HasKey(bc => new { bc.ProjectRightId, bc.UserId, bc.ProjectId});
            modelBuilder.Entity<ProjectRight>().HasData(
                new ProjectRight
                {
                    Id = 1,
                    Name = "READONLY",
                    Description = "User can only view project and its tasks."
                },
                new ProjectRight
                {
                    Id = 2,
                    Name = "ADMIN",
                    Description = "User has rights to read, modify and delete project."
                }
            );
            modelBuilder.UseIdentityColumns();
        }
    }
}
