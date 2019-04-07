﻿using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace jewText
{
    internal class Program
    {
        private static void Main()
        {
            Welcome();
        }

        private static void Welcome()
        {
            Console.Title = string.Format("jewText | v{0}", Variables.Version);
            Messages.Logo();
            if (Server.Backend.CheckConnection())
            {
                Server.Backend.LifeSwitch();
                Server.Backend.CheckBan();

                Messages.PrintWithPrefix("Welcome", "Press any key to continue.", "DeepSkyBlue");
                WebClient memeboxConnection = new WebClient();
                string memebox = memeboxConnection.DownloadString("http://www.jews-trash.tk/memebox.txt");
                byte[] data = Convert.FromBase64String(memebox);
                string memeboxDecoded = Encoding.UTF8.GetString(data);
                MessageBox.Show(memeboxDecoded,
                                "Meme box! (ಠ‿↼)",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Console.ReadKey();
                Menu();
            }
            else
            {
                Messages.Print("No connection.");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }

        private static void Menu()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Menu", Variables.Version);
            Messages.Logo();
            Messages.PrintWithPrefix("1", "Remove Duplicates", "DeepSkyBlue");
            Messages.PrintWithPrefix("2", "Remove Containing", "DeepSkyBlue");
            Messages.PrintWithPrefix("3", "Randomize Lines", "DeepSkyBlue");
            Messages.PrintWithPrefix("4", "Sort Lines", "DeepSkyBlue");
            Messages.PrintWithPrefix("5", "Find And Replace", "DeepSkyBlue");
            Messages.PrintWithPrefix("6", "Remove Empty Lines", "DeepSkyBlue");
            Messages.PrintWithPrefix("7", "Extract Column", "DeepSkyBlue");
            Messages.PrintWithPrefix("8", "Extract Regex", "DeepSkyBlue");
            Messages.PrintWithPrefix("9", "Prefix / Suffix To Lines", "DeepSkyBlue");
            Messages.PrintWithPrefix("10", "Extract Combos", "DeepSkyBlue");
            Messages.PrintWithPrefix("11", "Combo Combiner", "DeepSkyBlue");
            Messages.PrintWithPrefix("12", "Leech Combos", "DeepSkyBlue");
            Console.WriteLine();
            Messages.PrintWithPrefix("99", "Exit", "DeepSkyBlue");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RemoveDuplicates.Start();
                    break;

                case "2":
                    RemoveContaining.Start();
                    break;

                case "3":
                    RandomizeLines.Start();
                    break;

                case "4":
                    SortLines.Start();
                    break;

                case "5":
                    FindAndReplace.Start();
                    break;

                case "6":
                    RemoveEmptyLines.Start();
                    break;

                case "7":
                    ExtractColumn.Start();
                    break;

                case "8":
                    ExtractRegex.Start();
                    break;

                case "9":
                    PrefixAndSuffix.Start();
                    break;

                case "10":
                    ExtractCombos.Start();
                    break;

                case "11":
                    ComboCombiner.Start();
                    break;

                case "12":
                    LeechCombos.Start();
                    break;

                case "99":
                    DialogResult dialogResult = MessageBox.Show("Do you really want to leave me?",
                                                                "Exit? (ಥ﹏ಥ)",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        Menu();
                    }
                    break;

                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
    }
}