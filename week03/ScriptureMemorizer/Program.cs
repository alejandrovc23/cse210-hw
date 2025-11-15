using System;

class Program
{
    static void Main()
    {
        var reference = new Reference("John", 3, 16);
        var text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        var scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            var input = Console.ReadLine();
            if (input != null && input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // hide 3 each time (tweakable)
        }
    }
}
