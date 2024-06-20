//Создайте систему управления проектами, где каждый проект состоит из задач, а каждая задача может содержать подзадачи.
//Система должна поддерживать возможность глубокого клонирования проектов и задач.

//Требования:
//Создайте класс Task, который будет представлять задачу. Класс должен иметь следующие свойства:

//string Title - название задачи
//string Description - описание задачи
//DateTime DueDate - срок выполнения
//List<Task> SubTasks - список подзадач
//Реализуйте интерфейс ICloneable в классе Task, чтобы обеспечить глубокое клонирование задач и подзадач.

//using System.Xml.Linq;
//using System;
//using Microsoft.VisualBasic;

//var subTasks1 = new List<Task>();
//subTasks1.Add(new Task("subTask1", "описание подзадачи 1", new DateTime(2024, 06, 27), new List<Task>()));
//subTasks1.Add(new Task("subTask2", "описание подзадачи 2", new DateTime(2024, 07, 20), new List<Task>()));
//Task task1 = new Task("task1", "описание задачи 1", new DateTime(2020, 06, 27), subTasks1);

//Task task2 = (Task)task1.Clone();
//task1.PrintInfo(task1);
//Console.WriteLine("------------------------------------------");
//task2.PrintInfo(task2);
//Console.WriteLine("------------------------------------------");

//var subTasks2 = new List<Task>();
//subTasks2.Add(new Task("subTask2_1", "описание подзадачи 2_1", new DateTime(2024, 12, 01), new List<Task>()));
//subTasks2.Add(new Task("subTask2_2", "описание подзадачи 2_2", new DateTime(2024, 10, 10), new List<Task>()));
//task2.DueDate = new DateTime(2024, 07, 07);
//task2.SubTasks = subTasks2;
//task2.Title = "TASK2";
//task1.PrintInfo(task1);
//Console.WriteLine("------------------------------------------");
//task2.PrintInfo(task2);


TestCloning();

void TestCloning()
{
    var subTasks1 = new List<Task>();
    subTasks1.Add(new Task("subTask1", "описание подзадачи 1", new DateTime(2024, 06, 27), new List<Task>()));
    subTasks1.Add(new Task("subTask2", "описание подзадачи 2", new DateTime(2024, 07, 20), new List<Task>()));

    Task task1 = new Task("task1", "описание задачи 1", new DateTime(2024, 06, 27), subTasks1);

    var subTasks2 = new List<Task>();
    subTasks2.Add(new Task("subTask2_1", "описание подзадачи 2_1", new DateTime(2024, 12, 01), new List<Task>()));
    subTasks2.Add(new Task("subTask2_2", "описание подзадачи 2_2", new DateTime(2024, 10, 10), new List<Task>()));
    Task task2 = new Task("task2", "описание задачи 2", new DateTime(2024, 12, 27), subTasks2);

    var AllTasks = new List<Task>();
    AllTasks.Add(task1);
    AllTasks.Add(task2);
    var Project1 = new Project("Program1", AllTasks);
    var Project2 = (Project)Project1.Clone();
    Project1.PrintProject(Project1);
    Console.WriteLine("-----------------------------------------");
    Project2.PrintProject(Project2);
    Console.WriteLine("-----------------------------------------");

    ChangeTaskName(Project1, "task1", "TASK_1");
    Project1.Name = "PROGRAM1";
    Project2.Name = "PROGRAM2";

    var subTasks3 = new List<Task>();
    subTasks3.Add(new Task("subTask3-1", "описание подзадачи 3-1", new DateTime(2024, 08, 27), new List<Task>()));
    subTasks3.Add(new Task("subTask3-2", "описание подзадачи 3-2", new DateTime(2024, 08, 20), new List<Task>()));

    Task task3 = new Task("task3", "описание задачи 3", new DateTime(2024, 06, 27), subTasks3);

    var subTasks4 = new List<Task>();
    subTasks4.Add(new Task("subTask4_1", "описание подзадачи 4_1", new DateTime(2024, 12, 01), new List<Task>()));
    subTasks4.Add(new Task("subTask4_2", "описание подзадачи 4_2", new DateTime(2024, 10, 10), new List<Task>()));
    Task task4 = new Task("task4", "описание задачи 4", new DateTime(2024, 12, 27), subTasks4);

    var AllTasks2 = new List<Task>();
    AllTasks2.Add(task3);
    AllTasks2.Add(task4);
    Project2.Tasks = AllTasks2;

    Project1.PrintProject(Project1);
    Console.WriteLine("-----------------------------------------");
    Project2.PrintProject(Project2);
    Console.WriteLine("-----------------------------------------");
}

void ChangeTaskName(Project p, string title, string newTitle)
{
    foreach (var t in p.Tasks)
    {
        if (t.Title == title)
            t.Title = newTitle;
    }
}
class Task :ICloneable
{
    public string Title { get; set; }                 // название задачи
    public string Description { get; set; }           // описание задачи
    public DateTime DueDate { get; set; }             // срок выполнения
    public List<Task> SubTasks { get; set; }           // список подзадач

    public Task(string title, string description, DateTime dueDate, List<Task> subtasks)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        SubTasks = subtasks;
    }

    public object Clone()
    {
        var newSubTasks = new List<Task>();
        foreach (var subT in SubTasks)
        {
            newSubTasks.Add((Task)subT.Clone());
        }
        return new Task(Title, Description, DueDate, newSubTasks);
    }
    public void PrintInfo(Task t)
    {
        Console.WriteLine($"задача - {t.Title}\nописание задачи - {t.Description},\nсрок выполнения - {t.DueDate}");
        foreach (var subT in t.SubTasks)
        {
            Console.WriteLine();
            PrintInfo(subT);
        }
    }
}


//Создайте класс Project, который будет представлять проект. Класс должен иметь следующие свойства:

//string Name - название проекта
//List<Task> Tasks - список задач
//Реализуйте интерфейс ICloneable в классе Project, чтобы обеспечить глубокое клонирование проектов и всех их задач.

//Напишите метод void PrintProject(Project project), который будет выводить информацию о проекте и всех его задачах на консоль.

//Напишите метод void TestCloning(), который будет выполнять следующие действия:

//Создавать экземпляр проекта с несколькими задачами и подзадачами.
//Клонировать проект.
//Вносить изменения в оригинальный проект (например, изменять название задачи, добавлять или удалять подзадачи).
//Выводить на консоль информацию об оригинальном и клонированном проектах до и после внесения изменений, чтобы продемонстрировать,
//что клонирование было глубоким и изменения в оригинале не повлияли на клон.

class Project : ICloneable
{

    public string Name { get; set; }                  // название проекта
    public List<Task> Tasks { get; set; }             // список задач

    public Project(string name, List<Task> tasks)
    {
        Name = name;
        Tasks = tasks;
    }
    public object Clone()
    {
        var newTasks = new List<Task>();
        foreach (var T in Tasks)
        {
            newTasks.Add((Task)T.Clone());
        }
        return new Project(Name, newTasks);
    }
    public void PrintProject(Project project)
    {
        Console.WriteLine($"проект - {project.Name}");
        foreach (var T in project.Tasks)
        {
            Console.WriteLine();
            T.PrintInfo(T);
        }
    }
}

