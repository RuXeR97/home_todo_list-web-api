namespace Home_todo_list___infrastructure.Entities
{
    public class ProjectAuthor
    {
        public int UserId { get; set; }
        public User Author { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
