using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaStreams.Common.Helpers
{
    public class ColourConsole
    {
        public static void WriteLineGreen(string message)
        {
            var beforeColour = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColour;
        }
        public static void WriteLineYellow(string message)
        {
            var beforeColour = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColour;
        }
        public static void WriteLineRed(string message)
        {
            var beforeColour = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColour;
        }
        public static void WriteLineCyan(string message)
        {
            var beforeColour = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColour;
        }
        public static void WriteLineGray(string message)
        {
            var beforeColour = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColour;
        }
        public static void WriteLineWhite(string message)
        {
            var beforeColour = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColour;
        }
        public static void WriteLineMagenta(string message)
        {
            var beforeColour = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(message);

            Console.ForegroundColor = beforeColour;
        }
    }
}
