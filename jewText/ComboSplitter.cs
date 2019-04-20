using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace jewText
{
    internal class ComboSplitter
    {
        public static void Start()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Combo Splitter", Variables.Version);
            Messages.PrintWithPrefix("Input", "Please choose a file.", "DeepSkyBlue");

            var file = new OpenFileDialog();

            file.Title = "Choose a text file";
            file.Filter = "Text files|*.txt";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                _path = file.FileName;
                Variables.Lines = File.ReadLines(_path ?? throw new InvalidOperationException()).ToList();
            }
            else
            {
                Program.Menu();
            }

            Console.Clear();
            Messages.PrintWithPrefix("Input", "Please choose the folder you want the files in.", "DeepSkyBlue");

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    _folder = fbd.SelectedPath;
                }
                else
                {
                    Program.Menu();
                }
            }

            ProcessInfo();
        }

        private static void ProcessInfo()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Loaded {Variables.Lines.Count} lines from the file!", "DeepSkyBlue");
            Messages.PrintWithPrefix("Continue", "Press any key to continue.", "Lime");
            Variables.Lines.Clear();
            Console.ReadKey();
            Process();
        }

        private static void Process()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "How much lines you want in a single file?", "DeepSkyBlue");
            string linesPerFile = Console.ReadLine();

            Console.Clear();
            Messages.PrintWithPrefix("Process", "Working... (If the file is BIG it will take a lot more time)", "DeepSkyBlue");

            int splitSize = Convert.ToInt32(linesPerFile);
            using (var lineIterator = File.ReadLines(_path).GetEnumerator())
            {
                bool stillGoing = true;
                for (int chunk = 0; stillGoing; chunk++)
                {
                    stillGoing = WriteChunk(lineIterator, splitSize, chunk);
                }
            }

            Done();
        }

        private static bool WriteChunk(IEnumerator<string> lineIterator, int splitSize, int chunk)
        {
            string filename = Path.GetFileName(_path);
            using (var writer = File.CreateText($"{_folder}\\{filename}_{chunk}.txt"))
            {
                for (int i = 0; i < splitSize; i++)
                {
                    if (!lineIterator.MoveNext())
                    {
                        return false;
                    }
                    writer.WriteLine(lineIterator.Current);
                }
            }
            return true;
        }

        private static void Done()
        {
            Console.Clear();
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Saved the splitted files! File location: {_folder}", "DeepSkyBlue");
            Messages.PrintWithPrefix("Done", "Press any key to close the program.", "DeepSkyBlue");
            Console.ReadKey();
        }

        private static string _path;
        private static string _folder;
    }
}