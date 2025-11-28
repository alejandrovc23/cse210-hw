using System;

class Program
{
    static void Main(string[] args)
    {
        int option = 0;

        while (option != 4)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nSelect a choice: ");

            option = int.Parse(Console.ReadLine());

            Console.Clear();

            if (option == 1)
            {
                BreathingActivity b = new BreathingActivity();
                b.Run();
            }
            else if (option == 2)
            {
                ReflectingActivity r = new ReflectingActivity();
                r.Run();
            }
            else if (option == 3)
            {
                ListingActivity l = new ListingActivity();
                l.Run();
            }
        }
    }
}
