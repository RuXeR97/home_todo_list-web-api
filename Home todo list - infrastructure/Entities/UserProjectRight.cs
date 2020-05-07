namespace Home_todo_list___infrastructure.Entities
{
    public class UserProjectRight
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProjectRightId { get; set; }
        public ProjectRight ProjectRight { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
