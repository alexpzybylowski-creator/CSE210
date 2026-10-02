using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void EndActivity(DateTime startTime)
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(2);

        DateTime endTime = DateTime.Now;
        double elapsed = (endTime - startTime).TotalSeconds;

        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} Activity.");
        Console.WriteLine($"Duration: {_duration} seconds.");
        Console.WriteLine($"Session time: {Math.Round(elapsed)} seconds.");

        ShowSpinner(3);
        Console.WriteLine();
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void ShowSpinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(symbols[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            index = (index + 1) % symbols.Length;
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void PauseWithSpinner(int seconds)
    {
        ShowSpinner(seconds);
        Console.WriteLine();
    }
}