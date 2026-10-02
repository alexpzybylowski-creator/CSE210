using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        StartActivity();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            int remaining = (int)Math.Ceiling(
                (endTime - DateTime.Now).TotalSeconds);

            Console.WriteLine();
            Console.WriteLine(
                breatheIn ? "Breathe in..." : "Breathe out...");

            Console.Write(" ");

            int pause = Math.Min(4, remaining);
            ShowCountdown(pause);

            Console.WriteLine();

            breatheIn = !breatheIn;
        }

        EndActivity(startTime);
    }
}