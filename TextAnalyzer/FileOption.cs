using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextAnalyzer
{
    public class FileOption
    {
        public FileOption()
        {
        }

        static string[] specialChar = new string[] { @"\", "|", "!", "#", "$", "%", "&", "/", "(", ")", "=", "?", "»", "«", "@", "£", "§", "€", "{", "}", ".", "-", "–", ";", "'", "<", ">", "_", "," };
        static  char[] escapeSequence = new char[] { '\r', '\n', '\t' };

        internal static void WordCount(string source)
        {
            string word = Helper.UserInput("Enter a word to find.");
            Console.WriteLine($"Count : {source.Split(' ').Where(w => w.ToLower() == word.ToLower()).Count()}\n");
        }

        internal static void CharCount(string source)
        {
            string @char = Helper.UserInput("Enter a char to find.");

            if (char.TryParse(@char, out char chartoFind))
                Console.WriteLine($"Count : {source.ToCharArray().Count(c => c == chartoFind)}\n");
            else
                Console.WriteLine("Please enter Invalid char.\n");
        }

        internal static void LineCount(string source)
        {
            Console.WriteLine($"Count : {source.Split('\r').Length}\n");
        }

        internal static void AllWordCount(string source)
        {
            Console.WriteLine($"Count : {source.Split(new char[] { ' ', '\r', '\n', '\t' }).Where(w => !string.IsNullOrEmpty(w) && !specialChar.Contains(w)).Count()}\n");
        }

        internal static void AllCharCount(string source)
        {
            Console.WriteLine($"Count : {source.ToArray().Where(c => !char.IsWhiteSpace(c)).Select(s => s).Count()}\nChar Count with Space: {source.ToCharArray().Where(w => !escapeSequence.Contains(w)).Count()}\n");
        }

        internal static void Occurring(string source)
        {
            var counts = Regex.Replace(source, @"[^0-9a-zA-Z\n\r\t/ ]+", "").Split(new char[] { ' ', '\r', '\n', '\t', '/' })
                                .GroupBy(g => g)
                                .OrderByDescending(g => g.Count())
                                .Select(w => new { w.Key, Count = w.Count(), Length = w.Key.Length })
                                .Where(w => !string.IsNullOrEmpty(w.Key)).ToList();


            var count = 1;

            Console.WriteLine($"Word and its frequency:\n");
            counts.Where(w => w.Count > 1).Take(5).ToList().ForEach(w => Console.WriteLine($"{count++}: {w.Key} => {w.Count} Times"));

            var longestWord = counts?.OrderByDescending(w => w.Length)?.FirstOrDefault();
            Console.WriteLine($"\nlongest word is [{longestWord?.Key}] with Length {longestWord?.Length}\n");
        }

        internal static void Cpmpare(string fileOneName)
        {
            var allFiles = File.ShowFiles();

            string fileTwoID = Helper.UserInput("Select 2nd File to Compare");

            if (!int.TryParse(fileTwoID, out int fileIndex))
            {
                Console.WriteLine("Invalid Selection\n");
                Console.Beep();
                return;
            }

            if (fileIndex < 1 || fileIndex > 4)
            {
                Console.WriteLine("Invalid Selection\n");
                Console.Beep();
                return;
            }

            var fileInfoOne = allFiles.Where(w => w.FullName == fileOneName).FirstOrDefault();
            var fileInfoTwo = allFiles[fileIndex - 1];
            Console.WriteLine($"Selected File: {fileInfoTwo.Name}\n");

            Console.WriteLine(Helper.CompareFiles(fileInfoOne.FullName, fileInfoTwo.FullName) ? "Files are Same" : "Files are Not Same\n");



        }


    }
}