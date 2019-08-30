using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace jewText
{
    internal class ComboCombiner
    {
        public static void Start()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Combo Combiner", Variables.Version);
            Messages.PrintWithPrefix("Input", "Please choose files that you want to combine.", "DeepSkyBlue");

            var file = new OpenFileDialog();

            file.Title = "Choose text files";
            file.Filter = "Text files|*.txt";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.Multiselect = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in file.FileNames)
                {
                    Variables.Lines = File.ReadLines(filename ?? throw new InvalidOperationException()).ToList();
                    foreach (string line in Variables.Lines)
                    {
                        CombinedCombosLines.Add(line);
                    }
                }
                Variables.Lines.Clear();
            }
            else
            {
                Program.Menu();
            }
            CombinedProcessInfo();
        }

        private static void CombinedProcessInfo()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"There are {CombinedCombosLines.Count} lines in the combined file!", "DeepSkyBlue");
            Messages.PrintWithPrefix("Continue", "Press any key to continue.", "Lime");
            Console.ReadKey();
            Done();
        }

        private static void Done()
        {
            Console.Clear();
            Messages.PrintWithPrefix("Input", "Please choose file location to save the file!", "DeepSkyBlue");

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = $"jewText - Combo Combiner - {CombinedCombosLines.Count} Lines";
            saveFile.Filter = "Text files|*.txt";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                {
                    foreach (string line in CombinedCombosLines)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            else
            {
                Program.Menu();
            }

            CombinedCombosLines.Clear();
            Console.Clear();
            Messages.PrintWithPrefix("Info", $"Saved the file! File location: {saveFile.FileName}", "DeepSkyBlue");
            Messages.PrintWithPrefix("Done", "Press any key to go back to the menu.", "DeepSkyBlue");
            Console.ReadKey();
            Program.Menu();
        }

        private static List<string> CombinedCombosLines = new List<string>();
    }
}