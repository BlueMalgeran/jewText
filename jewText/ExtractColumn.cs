using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jewText
{
    internal class ExtractColumn
    {
        public static void Start()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Extract Column", Variables.Version);
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
            ExtractColumn.ProcessInfo();
        }

        private static void ProcessInfo()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Loaded {Variables.Lines.Count} lines from the file!", "Aqua");
            Messages.PrintWithPrefix("Continue", "Press any key to continue.", "Lime");
            Console.ReadKey();
            ExtractColumn.Process();
        }

        private static void Process()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "Enter the character you want to extract... IT MUST BE 1 CHARACTER! (Exaple: |)", "Aqua");
            char column = char.Parse(Console.ReadLine());
            Console.WriteLine();
            Messages.PrintWithPrefix("Input", "Enter the argument number... (Example: jewdev1|jewdev2)", "Aqua");
            int number = int.Parse(Console.ReadLine());

            Console.Clear();
            Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "Aqua");

            foreach (var line in Variables.Lines)
            {
                string[] words = line.Split(column);
                ExtractedLines.Add(words[number - 1]);
            }
            Variables.Lines.Clear();

            ExtractColumn.Done();
        }

        private static void Done()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "File name?", "Aqua");
            var filename = Console.ReadLine();
            File.WriteAllLines(filename + ".txt", ExtractedLines);
            ExtractedLines.Clear();
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Saved the file in the name you have chosen: {filename}! (The file is probably in my file location!)", "Aqua");
            Messages.PrintWithPrefix("Done", "Press any key to close the program.", "Aqua");
            Console.ReadKey();
        }

        private static List<string> ExtractedLines = new List<string>();
    }
}