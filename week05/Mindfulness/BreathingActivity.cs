using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", 
        "This activity helps you relax by guiding you through slow breathing.")
    {
    }

    public void Run()
    {
        StartMessage();

        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("Breathe in... ");
            Countdown(4);
            Console.WriteLine();

            Console.Write("Breathe out... ");
            Countdown(6);
            Console.WriteLine();
            Console.WriteLine();
        }

        EndMessage();
    }
}
