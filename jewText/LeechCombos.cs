using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace jewText
{
    internal class LeechCombos
    {
        public static void Start()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Leech Combos", Variables.Version);
            Process();
        }

        private static void Process()
        {
            Messages.PrintWithPrefix("Input", "Please type the URL you want to leech combos from.", "DeepSkyBlue");
            string url = Console.ReadLine();

            Console.Clear();
            Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "DeepSkyBlue");

            WebClient connection = new WebClient();
            string response = connection.DownloadString(url ?? throw new InvalidOperationException());

            foreach (Match match in Regex.Matches(response, @"([^\s]+?[:;][^\s]+)"))
            {
                Variables.Lines.Add(match.Value);
            }

            ProcessInfo();
        }

        private static void ProcessInfo()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Loaded {Variables.Lines.Count} lines from the URL!", "DeepSkyBlue");
            Messages.PrintWithPrefix("Continue", "Press any key to continue.", "Lime");
            Console.ReadKey();
            Done();
        }

        private static void Done()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "File name?", "DeepSkyBlue");
            var filename = Console.ReadLine();
            File.WriteAllLines(filename + ".txt", Variables.Lines);
            Variables.Lines.Clear();
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Saved the file in the name you have chosen: {filename}! (The file is probably in my file location!)", "DeepSkyBlue");
            Messages.PrintWithPrefix("Done", "Press any key to close the program.", "DeepSkyBlue");
            Console.ReadKey();
        }
    }
}