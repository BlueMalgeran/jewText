using Pastel;
using System;
using System.Drawing;

namespace jewText
{
    internal class Messages
    {
        public static void Logo()
        {
            Console.WriteLine(@"
 ▄▄▄██▀▀▀▓█████  █     █░▄▄▄█████▓▓█████ ▒██   ██▒▄▄▄█████▓
   ▒██   ▓█   ▀ ▓█░ █ ░█░▓  ██▒ ▓▒▓█   ▀ ▒▒ █ █ ▒░▓  ██▒ ▓▒
   ░██   ▒███   ▒█░ █ ░█ ▒ ▓██░ ▒░▒███   ░░  █   ░▒ ▓██░ ▒░
▓██▄██▓  ▒▓█  ▄ ░█░ █ ░█ ░ ▓██▓ ░ ▒▓█  ▄  ░ █ █ ▒ ░ ▓██▓ ░
 ▓███▒   ░▒████▒░░██▒██▓   ▒██▒ ░ ░▒████▒▒██▒ ▒██▒  ▒██▒ ░
 ▒▓▒▒░   ░░ ▒░ ░░ ▓░▒ ▒    ▒ ░░   ░░ ▒░ ░▒▒ ░ ░▓ ░  ▒ ░░
 ▒ ░▒░    ░ ░  ░  ▒ ░ ░      ░     ░ ░  ░░░   ░▒ ░    ░
 ░ ░ ░      ░     ░   ░    ░         ░    ░    ░    ░
 ░   ░      ░  ░    ░   Coded By jewdev   ░    ░
                                                           ".Pastel(Color.White));
        }

        public static void PrintWithPrefix(string prefix, string message, string prefixColor)
        {
            object locked = Messages.Locked;
            lock (locked)
            {
                Console.Write("[".Pastel(Color.White));
                Console.Write(prefix.Pastel(Color.FromName(prefixColor)));
                Console.WriteLine($"] {message}".Pastel(Color.White));
            }
        }

        public static void Print(string message)
        {
            object locked = Messages.Locked;
            lock (locked)
            {
                Console.WriteLine(message.Pastel(Color.White));
            }
        }

        private static readonly object Locked = new object();
    }
}