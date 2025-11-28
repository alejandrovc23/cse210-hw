using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("Enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> icons = new List<string>() { "|", "/", "-", "\\" };

        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(icons[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % icons.Count;
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
