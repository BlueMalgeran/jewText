using System;
using System.Windows.Forms;
using System.Net;
using System.Text;

namespace jewText
{
    internal class Program
    {
        private static void Main()
        {
            Program.Welcome();
        }

        private static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("https://www.bluemalgeran.xyz/memebox.txt"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private static void Welcome()
        {
            Console.Title = string.Format("jewText | v{0}", Variables.Version);
            Messages.Logo();
            Messages.PrintWithPrefix("Welcome", "Press any key to continue.", "Aqua");
            if (CheckForInternetConnection() == true)
            {
            WebClient memeboxConnection = new WebClient();
            string memebox = memeboxConnection.DownloadString("https://www.bluemalgeran.xyz/memebox.txt");
            byte[] data = Convert.FromBase64String(memebox);
            string memeboxDecoded = Encoding.UTF8.GetString(data);
            MessageBox.Show(memeboxDecoded,
                            "Meme box! (ಠ‿↼)",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            Console.ReadKey();
            Program.Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.Title = string.Format("jewText | v{0} | Menu", Variables.Version);
            Messages.Logo();
            Messages.PrintWithPrefix("1", "Remove Duplicates", "Aqua");
            Messages.PrintWithPrefix("2", "Remove Containing", "Aqua");
            Messages.PrintWithPrefix("3", "Randomize Lines", "Aqua");
            Messages.PrintWithPrefix("4", "Sort Lines", "Aqua");
            Messages.PrintWithPrefix("5", "Find And Replace", "Aqua");
            Messages.PrintWithPrefix("6", "Remove Empty Lines", "Aqua");
            Messages.PrintWithPrefix("7", "Extract Column", "Aqua");
            Messages.PrintWithPrefix("8", "Extract Regex", "Aqua");
            Messages.PrintWithPrefix("9", "Prefix / Suffix To Lines", "Aqua");
            Console.WriteLine();
            Messages.PrintWithPrefix("99", "Exit", "Aqua");
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
                        Program.Menu();
                    }
                    break;

                default:
                    Console.Clear();
                    Program.Menu();
                    break;
            }
        }
    }
}