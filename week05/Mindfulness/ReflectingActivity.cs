using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time you stood up for someone.",
        "Think of a time you accomplished something hard.",
        "Think of a time you helped someone in need."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself during this time?",
        "How can you apply this lesson today?",
        "What did this experience teach you about others?"
    };

    public ReflectingActivity()
        : base("Reflecting Activity",
        "This activity helps you reflect on times when you have shown strength or resilience.")
    {
    }

    public void Run()
    {
        StartMessage();

        Random rand = new Random();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {_prompts[rand.Next(_prompts.Count)]} ---\n");
        Console.WriteLine("Press enter when you're ready to continue...");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions:");
        ShowSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            string q = _questions[rand.Next(_questions.Count)];
            Console.Write($"> {q} ");
            ShowSpinner(5);
            Console.WriteLine("\n");
        }

        EndMessage();
    }
}
