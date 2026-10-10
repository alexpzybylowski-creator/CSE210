
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetLevel()
    {
        return (_score / 500) + 1;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You haven't created any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public int RecordEvent(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return 0;
        }

        int oldLevel = GetLevel();
        int earnedPoints = _goals[goalIndex].RecordEvent();

        _score += earnedPoints;

        if (earnedPoints > 0)
        {
            Console.WriteLine(
                $"\nCongratulations! You earned {earnedPoints} points!");

            Console.WriteLine($"Total score: {_score}");
            Console.WriteLine($"Current level: {GetLevel()}");

            if (GetLevel() > oldLevel)
            {
                Console.WriteLine(
                    "LEVEL UP! Keep up the great work!");
            }
        }
        else
        {
            Console.WriteLine(
                "No points earned. This goal may already be complete.");
        }

        return earnedPoints;
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine($"SCORE|{_score}");

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(
                        goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals and score saved successfully.");
        }
        catch (IOException)
        {
            Console.WriteLine("Error: Could not save the file.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: You do not have permission to save here.");
        }
    }

    public bool LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return false;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            List<Goal> loadedGoals = new List<Goal>();
            int loadedScore = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');

                if (parts.Length == 2 && parts[0] == "SCORE")
                {
                    if (int.TryParse(parts[1], out int score))
                    {
                        loadedScore = score;
                    }

                    continue;
                }

                if (parts.Length < 4 ||
                    !int.TryParse(parts[3], out int points))
                {
                    continue;
                }

                switch (parts[0])
                {
                    case "SimpleGoal":
                        if (parts.Length >= 5 &&
                            bool.TryParse(parts[4], out bool isComplete))
                        {
                            SimpleGoal simpleGoal = new SimpleGoal(
                                parts[1],
                                parts[2],
                                points);

                            if (isComplete)
                            {
                                simpleGoal.RecordEvent();
                            }

                            loadedGoals.Add(simpleGoal);
                        }
                        break;

                    case "EternalGoal":
                        loadedGoals.Add(
                            new EternalGoal(
                                parts[1],
                                parts[2],
                                points));
                        break;

                    case "ChecklistGoal":
                        if (parts.Length >= 7 &&
                            int.TryParse(parts[4], out int targetCount) &&
                            int.TryParse(parts[5], out int completedCount) &&
                            int.TryParse(parts[6], out int bonus) &&
                            targetCount > 0 &&
                            completedCount >= 0 &&
                            bonus >= 0)
                        {
                            loadedGoals.Add(
                                new ChecklistGoal(
                                    parts[1],
                                    parts[2],
                                    points,
                                    targetCount,
                                    bonus,
                                    completedCount));
                        }
                        break;
                }
            }

            _goals = loadedGoals;
            _score = loadedScore;

            Console.WriteLine("Goals and score loaded successfully.");
            return true;
        }
        catch (IOException)
        {
            Console.WriteLine("Error: Could not read the save file.");
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: You do not have permission to read this file.");
            return false;
        }
    }
}
