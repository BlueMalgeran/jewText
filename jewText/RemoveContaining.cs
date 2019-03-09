using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jewText
{
    internal class RemoveContaining
    {
        public static void Start()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Remove Containing", Variables.Version);
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

            RemoveContaining.ProcessInfo();
        }

        private static void ProcessInfo()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Loaded {Variables.Lines.Count} lines from the file!", "Aqua");
            Messages.PrintWithPrefix("Continue", "Press any key to continue.", "Aqua");
            Console.ReadKey();
            RemoveContaining.Process();
        }

        private static void Process()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "What is the text?", "Aqua");
            string textToRemove = Console.ReadLine();
            Console.Clear();
            Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "Aqua");

            foreach (string line in Variables.Lines)
            {
                if (!line.Contains(textToRemove))
                {
                    RemovedLines.Add(line);
                }
            }
            Variables.Lines.Clear();

            RemoveContaining.Done();
        }

        private static void Done()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "File name?", "Aqua");
            var filename = Console.ReadLine();
            File.WriteAllLines(filename + ".txt", RemovedLines);
            RemovedLines.Clear();
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Saved the file in the name you have chosen: {filename}! (The file is probably in my file location!)", "Aqua");
            Messages.PrintWithPrefix("Done", "Press any key to close the program.", "Aqua");
            Console.ReadKey();
        }

        private static List<string> RemovedLines = new List<string>();
    }
}