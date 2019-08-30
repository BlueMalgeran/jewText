using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace jewText
{
    internal class SortLines
    {
        public static void Start()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Sort Lines", Variables.Version);
            Messages.PrintWithPrefix("Input", "Please choose a file.", "DeepSkyBlue");

            var file = new OpenFileDialog();

            file.Title = "Choose a text file";
            file.Filter = "Text files|*.txt";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                string path = file.FileName;
                Variables.Lines = File.ReadLines(path ?? throw new InvalidOperationException()).ToList();
            }
            else
            {
                Program.Menu();
            }
            ProcessInfo();
        }

        private static void ProcessInfo()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Loaded {Variables.Lines.Count} lines from the file!", "DeepSkyBlue");
            Messages.PrintWithPrefix("Continue", "Press any key to continue.", "DeepSkyBlue");
            Console.ReadKey();
            Options();
        }

        private static void Options()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", "Please choose a type of sorting.", "DeepSkyBlue");
            Console.WriteLine();
            Messages.PrintWithPrefix("1", "Sort By Alphabetically", "DeepSkyBlue");
            Messages.PrintWithPrefix("2", "Sort By Length", "DeepSkyBlue");
            Messages.PrintWithPrefix("3", "Reverse", "DeepSkyBlue");
            Messages.PrintWithPrefix("4", "Randomize", "DeepSkyBlue");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "DeepSkyBlue");

                    Variables.Lines.Sort();
                    Done();
                    break;

                case "2":
                    Console.Clear();
                    Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "DeepSkyBlue");

                    Variables.Lines.Sort((a, b) => a.Length.CompareTo(b.Length));
                    Done();
                    break;

                case "3":
                    Console.Clear();
                    Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "DeepSkyBlue");

                    Variables.Lines.Reverse();
                    Done();
                    break;

                case "4":
                    Console.Clear();
                    Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "DeepSkyBlue");

                    var randomizeListlist = Variables.Lines.OrderBy(a => Guid.NewGuid()).ToList();
                    Variables.Lines.Clear();
                    foreach (string line in randomizeListlist)
                    {
                        Variables.Lines.Add(line);
                    }
                    Done();
                    break;
            }
        }

        private static void Done()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "Please choose file location to save the file!", "DeepSkyBlue");

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = $"jewText - Sort Lines - {Variables.Lines.Count} Lines";
            saveFile.Filter = "Text files|*.txt";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                {
                    foreach (string line in Variables.Lines)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            else
            {
                Program.Menu();
            }

            Variables.Lines.Clear();
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Saved the file! File location: {saveFile.FileName}", "DeepSkyBlue");
            Messages.PrintWithPrefix("Done", "Press any key to go back to the menu.", "DeepSkyBlue");
            Console.ReadKey();
            Program.Menu();
        }
    }
}