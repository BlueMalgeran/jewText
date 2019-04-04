using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jewText
{
    internal class ComboCombiner
    {
        public static void Start()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Combo Combiner", Variables.Version);
            Messages.PrintWithPrefix("Input", "Please drag your file to the program.", "DeepSkyBlue");

            string file = Console.ReadLine();
            bool brackets = file != null && file.Contains("\"");
            string path;
            if (brackets)
            {
                path = file.Replace("\"", "");
            }
            else
            {
                path = file;
            }

            Variables.Lines = File.ReadLines(path ?? throw new InvalidOperationException()).ToList();
            foreach (string line in Variables.Lines)
            {
                CombinedCombosLines.Add(line);
            }
            ProcessInfo();
        }

        private static void ProcessInfo()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Loaded {Variables.Lines.Count} lines from the file!", "DeepSkyBlue");
            Messages.PrintWithPrefix("Continue", "Press any key to continue.", "Lime");
            Console.ReadKey();
            Process();
        }

        private static void CombinedProcessInfo()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"There are {CombinedCombosLines.Count} lines in the combined file!", "DeepSkyBlue");
            Messages.PrintWithPrefix("Continue", "Press any key to continue.", "Lime");
            Console.ReadKey();
            Process();
        }

        private static void Process()
        {
            Console.Clear();

            Messages.PrintWithPrefix("Input", "Do want to add another file? (Y)es / (N)o", "DeepSkyBlue");
            string answer = Console.ReadLine();
            if (answer != null && answer.StartsWith("y"))
            {
                Console.Clear();
                Messages.PrintWithPrefix("Input", "Please drag ANOTHER file to the program.", "DeepSkyBlue");

                string file = Console.ReadLine();
                bool brackets = file != null && file.Contains("\"");
                string path;
                if (brackets)
                {
                    path = file.Replace("\"", "");
                }
                else
                {
                    path = file;
                }

                Variables.Lines = File.ReadLines(path ?? throw new InvalidOperationException()).ToList();
                foreach (string line in Variables.Lines)
                {
                    CombinedCombosLines.Add(line);
                }
                CombinedProcessInfo();
            }
            else
            {
                Done();
            }
        }

        private static void Done()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "File name?", "DeepSkyBlue");
            var filename = Console.ReadLine();
            File.WriteAllLines(filename + ".txt", CombinedCombosLines);
            Variables.Lines.Clear();
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Saved the file in the name you have chosen: {filename}! (The file is probably in my file location!)", "DeepSkyBlue");
            Messages.PrintWithPrefix("Done", "Press any key to close the program.", "DeepSkyBlue");
            Console.ReadKey();
        }

        private static List<string> CombinedCombosLines = new List<string>();
    }
}