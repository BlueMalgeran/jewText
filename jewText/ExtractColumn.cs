using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace jewText
{
    internal class ExtractColumn
    {
        public static void Start()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Extract Column", Variables.Version);
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
            Messages.PrintWithPrefix("Input", "Enter the character you want to extract...", "DeepSkyBlue");
            string column = Console.ReadLine();
            Console.WriteLine();
            Messages.PrintWithPrefix("Input", "Enter the argument number... (Example: 1|2|3|4|5)", "DeepSkyBlue");
            int number = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.Clear();
            Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "DeepSkyBlue");

            foreach (var line in Variables.Lines)
            {
                string[] words = line.Split(new[] { column }, StringSplitOptions.None);
                ExtractedLines.Add(words[number - 1]);
            }
            Variables.Lines.Clear();

            Done();
        }

        private static void Done()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "Please choose file location to save the file!", "DeepSkyBlue");

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = $"jewText - Extract Column - {ExtractedLines.Count} Lines";
            saveFile.Filter = "Text files|*.txt";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                {
                    foreach (string line in ExtractedLines)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            else
            {
                Program.Menu();
            }
            ExtractedLines.Clear();
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Saved the file! File location: {saveFile.FileName}", "DeepSkyBlue");
            Messages.PrintWithPrefix("Done", "Press any key to close the program.", "DeepSkyBlue");
            Console.ReadKey();
        }

        private static List<string> ExtractedLines = new List<string>();
    }
}