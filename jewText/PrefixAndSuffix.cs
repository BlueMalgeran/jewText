using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace jewText
{
    internal class PrefixAndSuffix
    {
        public static void Start()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Prefix / Suffix To Lines", Variables.Version);
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
            Messages.PrintWithPrefix("Continue", "Press any key to continue.", "Lime");
            Console.ReadKey();
            Process();
        }

        private static void Process()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "Prefix for the lines? (Leave blank for no prefix)", "DeepSkyBlue");
            string prefix = Console.ReadLine();
            Console.WriteLine();
            Messages.PrintWithPrefix("Input", "Suffix for the lines? (Leave blank for no suffix)", "DeepSkyBlue");
            string suffix = Console.ReadLine();

            Console.Clear();
            Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "DeepSkyBlue");

            foreach (var line in Variables.Lines)
            {
                string finishedLine = prefix + line + suffix;
                FinishedLines.Add(finishedLine);
            }
            Variables.Lines.Clear();

            Done();
        }

        private static void Done()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "Please choose file location to save the file!", "DeepSkyBlue");

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = $"jewText - Prefix And Suffix - {FinishedLines.Count} Lines";
            saveFile.Filter = "Text files|*.txt";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                {
                    foreach (string line in FinishedLines)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            else
            {
                Program.Menu();
            }
            FinishedLines.Clear();
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Saved the file! File location: {saveFile.FileName}", "DeepSkyBlue");
            Messages.PrintWithPrefix("Done", "Press any key to close the program.", "DeepSkyBlue");
            Console.ReadKey();
        }

        private static List<string> FinishedLines = new List<string>();
    }
}