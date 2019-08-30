using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace jewText
{
    internal class Program
    {
        [STAThread]
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
                Messages.PrintWithPrefix("Welcome", "Press any key to continue.", "DeepSkyBlue");
                WebClient memeboxConnection = new WebClient();
                string memebox = memeboxConnection.DownloadString("https://www.bluemalgeran.xyz/memebox.txt");
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

        public static void Menu()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Menu", Variables.Version);
            Messages.Logo();
            Messages.PrintWithPrefix("1", "Remove Duplicates", "DeepSkyBlue");
            Messages.PrintWithPrefix("2", "Remove Containing", "DeepSkyBlue");
            Messages.PrintWithPrefix("3", "Sort Lines", "DeepSkyBlue");
            Messages.PrintWithPrefix("4", "Find And Replace", "DeepSkyBlue");
            Messages.PrintWithPrefix("5", "Remove Empty Lines", "DeepSkyBlue");
            Messages.PrintWithPrefix("6", "Extract Column", "DeepSkyBlue");
            Messages.PrintWithPrefix("7", "Extract Regex", "DeepSkyBlue");
            Messages.PrintWithPrefix("8", "Prefix / Suffix To Lines", "DeepSkyBlue");
            Messages.PrintWithPrefix("9", "Extract Combos", "DeepSkyBlue");
            Messages.PrintWithPrefix("10", "Combo Combiner", "DeepSkyBlue");
            Messages.PrintWithPrefix("11", "Leech Combos", "DeepSkyBlue");
            Messages.PrintWithPrefix("12", "Combo Splitter", "DeepSkyBlue");
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
                    SortLines.Start();
                    break;

                case "4":
                    FindAndReplace.Start();
                    break;

                case "5":
                    RemoveEmptyLines.Start();
                    break;

                case "6":
                    ExtractColumn.Start();
                    break;

                case "7":
                    ExtractRegex.Start();
                    break;

                case "8":
                    PrefixAndSuffix.Start();
                    break;

                case "9":
                    ExtractCombos.Start();
                    break;

                case "10":
                    ComboCombiner.Start();
                    break;

                case "11":
                    LeechCombos.Start();
                    break;

                case "12":
                    ComboSplitter.Start();
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