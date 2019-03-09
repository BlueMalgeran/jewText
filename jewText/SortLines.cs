using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jewText
{
    internal class SortLines
    {
        public static void Start()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Sort Lines", Variables.Version);
            Messages.PrintWithPrefix("Input", "Please drag your file to the program.", "Aqua");

            string file = Console.ReadLine();
            bool brackets = file.Contains("\"");
            string path;
            if (brackets)
            {
                path = file.Replace("\"", "");
            }
            else
            {
                path = file;
            }
            Variables.Lines = File.ReadLines(path).ToList<string>();

            SortLines.ProcessInfo();
        }

        private static void ProcessInfo()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Loaded {Variables.Lines.Count} lines from the file!", "Aqua");
            Messages.PrintWithPrefix("Continue", "Press any key to continue.", "Aqua");
            Console.ReadKey();
            SortLines.Options();
        }

        private static void Options()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", "Please choose a type of sorting.", "Aqua");
            Messages.PrintWithPrefix("1", "Sort By Alphabetically", "Aqua");
            Messages.PrintWithPrefix("2", "Sort By Length", "Aqua");
            Messages.PrintWithPrefix("3", "Reverse", "Aqua");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "Aqua");

                    Variables.Lines.Sort();
                    SortLines.Done();
                    break;

                case "2":
                    Console.Clear();
                    Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "Aqua");

                    Variables.Lines.Sort((a, b) => a.Length.CompareTo(b.Length));
                    SortLines.Done();
                    break;

                case "3":
                    Console.Clear();
                    Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "Aqua");

                    Variables.Lines.Reverse();
                    SortLines.Done();
                    break;
            }
        }

        private static void Done()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "File name?", "Aqua");
            var filename = Console.ReadLine();
            File.WriteAllLines(filename + ".txt", Variables.Lines);
            Variables.Lines.Clear();
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Saved the file in the name you have chosen: {filename}! (The file is probably in my file location!)", "Aqua");
            Messages.PrintWithPrefix("Done", "Press any key to close the program.", "Aqua");
            Console.ReadKey();
        }
    }
}