
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        // Creativity beyond the requirements:
        // The program includes a level system, level-up messages,
        // and bonus points for completing checklist goals.
        while (running)
        {
            Console.WriteLine("\n=== ETERNAL QUEST ===");
            Console.WriteLine($"Score: {manager.GetScore()} points");
            Console.WriteLine($"Level: {manager.GetLevel()}");
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    RecordGoalEvent(manager);
                    break;

                case "4":
                    Console.Write("Enter a filename to save: ");
                    string saveFile = Console.ReadLine() ?? "goals.txt";

                    if (string.IsNullOrWhiteSpace(saveFile))
                    {
                        saveFile = "goals.txt";
                    }

                    manager.SaveToFile(saveFile);
                    break;

                case "5":
                    Console.Write("Enter a filename to load: ");
                    string loadFile = Console.ReadLine() ?? "goals.txt";

                    if (string.IsNullOrWhiteSpace(loadFile))
                    {
                        loadFile = "goals.txt";
                    }

                    manager.LoadFromFile(loadFile);
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Goodbye! Keep working on your Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nChoose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Type: ");

        string type = Console.ReadLine() ?? "";

        Console.Write("Goal name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Goal description: ");
        string description = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Goal name cannot be empty.");
            return;
        }

        Console.Write("Points for each completion: ");
        if (!int.TryParse(Console.ReadLine(), out int points) || points <= 0)
        {
            Console.WriteLine("Please enter a positive number of points.");
            return;
        }

        Goal goal;

        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;

            case "2":
                goal = new EternalGoal(name, description, points);
                break;

            case "3":
                Console.Write("How many times must you complete this goal? ");

                if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
                {
                    Console.WriteLine("The target must be a positive number.");
                    return;
                }

                Console.Write("Bonus points for completing the goal: ");

                if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
                {
                    Console.WriteLine("The bonus cannot be negative.");
                    return;
                }

                goal = new ChecklistGoal(
                    name, description, points, target, bonus);
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        manager.AddGoal(goal);
        Console.WriteLine("Goal created successfully!");
    }

    static void RecordGoalEvent(GoalManager manager)
    {
        manager.DisplayGoals();

        Console.Write("\nEnter the number of the goal to record: ");

        if (!int.TryParse(Console.ReadLine(), out int goalNumber))
        {
            Console.WriteLine("Please enter a valid number.");
            return;
        }

        manager.RecordEvent(goalNumber - 1);
    }
}


