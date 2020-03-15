using Home_todo_list___infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Home_todo_list___infrastructure.Other
{
    public class HomeTodoListDbContext : DbContext
    {
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectRight> ProjectRights { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:hometodolist-webapi20200310090004dbserver.database.windows.net,1433;Initial Catalog=Hometodolist-webapi20200310090004_db;Persist Security Info=False;User ID=ruxer;Password=EZy49YgLrT5DxUwqsz2B;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectAuthor>()
                .HasKey(bc => new { bc.ProjectId, bc.UserId });
            modelBuilder.Entity<UserProjectRight>()
                .HasKey(bc => new { bc.ProjectRightId, bc.UserId });

            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "William",
                LastName = "Shakespeare",
                Username = "xd"
            });
        }
    }
}
