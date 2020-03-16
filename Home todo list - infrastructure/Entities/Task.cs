using System;

namespace Home_todo_list___infrastructure.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan PredictionTimeMinutes { get; set; }
        public TimeSpan RealOverallTimeMinutes { get; set; }
    }
}
