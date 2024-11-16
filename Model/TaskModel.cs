namespace ToDoAppAPI.Model
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public int TaskPriority { get; set; }
    }
}
