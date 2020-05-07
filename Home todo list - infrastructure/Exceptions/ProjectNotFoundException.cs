namespace Home_todo_list___infrastructure.Exceptions
{
    public class ProjectNotFoundException : NotFoundException
    {
        public ProjectNotFoundException(int id) : base($"Project with id={id} was not found.")
        {
        }

        public ProjectNotFoundException (int[] ids) : base($"Project with given ids were not found={ids} was not found.")
        {

        }
    }
}
