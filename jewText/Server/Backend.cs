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
                using (client.OpenRead("https://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}