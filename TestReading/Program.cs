using System;
using System.IO;

namespace TestReading
{
    /// <summary>
    /// TODO:
    /// Proper Method and Variable Name
    /// Move all method in Class
    /// Negative Validation
    /// Spell and cosmatic change
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("----Text Analyzer-----\n");

            bool exit = false;
            while (!exit)
            {
                var fileDetails = File.GetFiles( out bool isExit);

                if (isExit)
                {
                    exit = isExit;
                    Console.WriteLine("Closing Text Analyzer\n");
                    Console.Beep();
                    continue;
                }

                if (fileDetails == null) continue;

                bool exitOptions = false;
                while (!exitOptions)
                {
                    exitOptions = File.Options(fileDetails);
                }
            }

            Helper.UserInput("Thank You\nPress Enter to Exit");
        }
    }
}