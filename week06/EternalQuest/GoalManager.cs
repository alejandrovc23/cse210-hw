using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void MainMenu()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("\n--- Goal Tracker ---");
            Console.WriteLine($"Score: {_score}\n");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. SimpleGoal");
        Console.WriteLine("2. EternalGoal");
        Console.WriteLine("3. ChecklistGoal");

        int type = int.Parse(Console.ReadLine());

        Console.Write("Goal name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == 3)
        {
            Console.Write("Target completions: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(file))
        {
            output.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                output.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        string[] lines = File.ReadAllLines(file);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            string type = parts[0];
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[4]);
                _goals.Add(new SimpleGoal(name, desc, points, isComplete));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(name, desc, points));
            }
            else if (type == "ChecklistGoal")
            {
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountDone = int.Parse(parts[6]);

                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus, amountDone));
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    private void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
    }
}
