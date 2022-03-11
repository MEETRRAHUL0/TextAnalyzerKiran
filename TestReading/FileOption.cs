using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestReading
{
    public class FileOption
    {
        public FileOption()
        {
        }



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
            Console.WriteLine($"Count : {source.Split(' ').Count()}\n");
        }

        internal static void AllCharCount(string source)
        {
            Console.WriteLine($"Count : {source.ToArray().Where(c => !char.IsWhiteSpace(c)).Select(s => s).Count()}\nChar Count with Space: {source.ToCharArray().Count()}\n");
        }

        internal static void Occurring(string source)
        {
            var counts = Regex.Replace(source, @"[^0-9a-zA-Z ]+", "").Split(' ')
                                .GroupBy(g => g)
                                .OrderByDescending(g => g.Count())
                                .Select(w => new { w.Key, count = w.Count(), Length = w.Key.Length })
                                .Where(w => w.count > 1).ToList();

            var count = 1;

            Console.WriteLine($"Word and its frequency:\n");
            counts.ForEach(w => Console.WriteLine($"{count++}: {w.Key} => {w.count} Times"));

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