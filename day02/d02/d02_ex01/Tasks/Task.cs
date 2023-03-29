namespace s21
{
    internal class Task
    {
        public string? Title { get; private set; }
        public string? Description { get; private set; }

        public DateTime? DueDate { get; private set; } = null;

        public TaskPriority? Priority { get; private set; } = TaskPriority.Normal;

        public TaskType Type { get; private set; }

        public TaskState CurrentState { get; private set; } = TaskState.New;
        

        public void SetTitle(string? title)
        {
            Title = title;
        }

        public void SetDescription(string? description)
        {
            Description = description;
        }

        public bool TrySetDeadline(string? date)
        {
            if (!DateTime.TryParse(date, out var result))
            { 
                return false; 
            }
            DueDate = result;
            return true;
        }

        public bool TrySetPriority(string? priority)
        {
            if (!Enum.TryParse(typeof(TaskPriority), priority, true, out var result) || result is null) {
                return false;
            }
            Priority = (TaskPriority)result;
            return true;
        }

        public bool TrySetType(string? type)
        {
            if (!Enum.TryParse(typeof(TaskType), type, true, out var result) || result is null)
            {
                return false;
            }
            Type = (TaskType)result;
            return true;
        }

        public void SetState(TaskState state)
        {
            CurrentState = state;
        }

        public override string ToString()
        {
            var deadline = DueDate is null ? "" : $", Due till {DueDate:MM/dd/yyyy}";
            return $"- {Title}\n" +
                $"[{Type}] [{CurrentState}]\n" +
                $"Priority: {Priority}{deadline}\n" +
                $"{Description}";
        }
    }
}
