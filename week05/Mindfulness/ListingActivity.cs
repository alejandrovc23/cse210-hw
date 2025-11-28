using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "List as many things as you can that you are grateful for.",
        "List the people who have made a positive impact on your life.",
        "List things that make you smile."
    };

    public ListingActivity()
        : base("Listing Activity",
        "This activity helps you reflect by listing as many items as you can.")
    {
    }

    public void Run()
    {
        StartMessage();

        Random rand = new Random();
        Console.WriteLine("List the following:");
        Console.WriteLine($"--- {_prompts[rand.Next(_prompts.Count)]} ---\n");

        Console.Write("You may begin in: ");
        Countdown(5);
        Console.WriteLine();

        int count = 0;
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
        EndMessage();
    }
}
