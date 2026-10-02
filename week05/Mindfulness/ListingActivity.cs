using System;

public class ListingActivity : Activity
{
    private readonly string[] _prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        StartActivity();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        Random random = new Random();

        string prompt = _prompts[random.Next(_prompts.Length)];

        Console.WriteLine();
        Console.WriteLine(
            "List as many responses as you can to the following prompt:");

        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountdown(5);

        Console.WriteLine();
        Console.WriteLine();

        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            string answer = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(answer))
            {
                count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {count} items!");

        EndActivity(startTime);
    }
}