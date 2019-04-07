using System;
using System.Net;
using System.Threading;

namespace jewText.Server
{
    internal class Backend
    {
        public static bool CheckConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.jews-trash.tk/api.php"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void LifeSwitch()
        {
            WebClient lifeSwitchWebClient = new WebClient();
            string lifeSwitchString = lifeSwitchWebClient.DownloadString("http://www.jews-trash.tk/jewtextswitch.txt");
            if (lifeSwitchString.StartsWith("off".ToLower()))
            {
                Messages.Print("Sorry, the program is currently disabled.");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }

        public static void CheckBan()
        {
            WebClient checkBanWebClient = new WebClient();
            string banned = checkBanWebClient.DownloadString("http://www.jews-trash.tk/checkban.php");
            if (banned.StartsWith("true".ToLower()))
            {
                Messages.Print("Sorry, your IP is banned.");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
    }
}