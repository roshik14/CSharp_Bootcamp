var tasks = new List<s21.Task>();

while (true)
{
    var command = Console.ReadLine();
    if (command == "quit" || command == "q")
    {
        break;
    }

    if (command == "add")
    {
        var task = CreateNewTask();
        if (task is null)
        {
            Console.WriteLine("Input error. Check the input data and repeat the request.");
            continue;
        }
        tasks.Add(task);
    }
    else if (command == "list")
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("The task list is still empty.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
    }
    else if (command == "done")
    {
        Console.WriteLine("Enter a title");
        if (!TryReadInputString(out var title))
        {
            Console.WriteLine("Input error. Check the input data and repeat the request.");
            continue;
        }
        if (!TryDoneTask(title, tasks))
        {
            Console.WriteLine("Input error. The task with this title was not found.");
        }
    }
    else if (command == "wontdo")
    {
        Console.WriteLine("Enter a title");
        if (!TryReadInputString(out var title))
        {
            Console.WriteLine("Input error. Check the input data and repeat the request.");
            continue;
        }
        if (!TryMakeIrrelevantTask(title, tasks))
        {
            Console.WriteLine("Input error. The task with this title was not found.");
        }
    }
    else
    {
        Console.WriteLine("Input error. Check the input data and repeat the request.");
    }
}


bool TryDoneTask(string? title, List<s21.Task> tasks)
{
    var isFound = false;
    foreach (var task in tasks.Where(x => x.Title == title && x.CurrentState != s21.TaskState.Irrelevant))
    {
        isFound = true;
        task.SetState(s21.TaskState.Completed);
        Console.WriteLine($"The task [{task.Title}] is completed!");
    }
    return isFound;
}

bool TryMakeIrrelevantTask(string? title, List<s21.Task> tasks)
{
    var isFound = false;
    foreach (var task in tasks.Where(t => t.Title == title && t.CurrentState != s21.TaskState.Completed))
    {
        isFound = true;
        task.SetState(s21.TaskState.Irrelevant);
        Console.WriteLine($"The task[{task.Title}] is not longer relevant");
    }
    return isFound;
}

s21.Task? CreateNewTask()
{
    var task = new s21.Task();
    Console.WriteLine("Enter a title");
    if (!TryReadInputString(out var title))
    {
        return null;
    }
    task.SetTitle(title);

    Console.WriteLine("Enter a description");
    TryReadInputString(out var description);
    task.SetDescription(description);

    Console.WriteLine("Enter a deadline");
    if (TryReadInputString(out var date) && !task.TrySetDeadline(date))
    {
        return null;
    }

    Console.WriteLine("Enter the type");
    if (!TryReadInputString(out var type) || !task.TrySetType(type))
    {
        return null;
    }

    Console.WriteLine("Assign the priority");
    if (TryReadInputString(out var priority) && !task.TrySetPriority(priority))
    {
        return null;
    }
    return task;
}

bool TryReadInputString(out string? input)
{
    input = Console.ReadLine();
    return !string.IsNullOrEmpty(input);
}