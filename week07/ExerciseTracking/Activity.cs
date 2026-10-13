
using System;
using System.Globalization;

public abstract class Activity
{
    private DateTime _date;
    private int _length;

    public DateTime Date
    {
        get { return _date; }
    }

    public int Length
    {
        get { return _length; }
    }

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    protected abstract string GetActivityName();

    public string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)} " +
               $"{GetActivityName()} ({Length} min) - " +
               $"Distance: {GetDistance():F1} miles, " +
               $"Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }
}
