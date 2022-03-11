using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestReading
{
    public class File
    {
        public static bool Options(FileInfo files)
        {
            Console.WriteLine(@"
    1. Enter a word and see how many times it occurs in the file.
    2. Enter a single character and see how many times it occurs in the file
    3. Get the number of lines in the file
    4. Get the number of words in the file
    5. Get the number of characters in the file

    6. Get most frequently occurring word, the longest word
    7. comparison between different text files

    [Type Exit for Exit options]

            ");

            var fileOption = Helper.UserInput("Select Options:");
            if (fileOption.ToLower() == "exit") return true;

            if (!int.TryParse(fileOption, out int SelectedOption))
            {
                Console.WriteLine("Input Must Be Integer\n");
                Console.Beep();
                return false;
            }

            var fileText = System.IO.File.ReadAllText(files.FullName);

            switch (SelectedOption)
            {
                case 1:
                    FileOption.WordCount(fileText);
                    break;

                case 2:
                    FileOption.CharCount(fileText);
                    break;

                case 3:
                    FileOption.LineCount(fileText);
                    break;

                case 4:
                    FileOption.AllWordCount(fileText);
                    break;

                case 5:
                    FileOption.AllCharCount(fileText);
                    break;

                case 6:
                    FileOption.Occurring(fileText);
                    break;

                case 7:
                    FileOption.Cpmpare(files.FullName);
                    break;

                default:
                    Console.WriteLine("Invalid Selection\n Please select correct Option\n");
                    Console.Beep();
                    break;
            }
            return false;
        }

        public static FileInfo GetFiles(out bool exit)
        {
            var files = ShowFiles();
            exit = false;

            string fileId = Helper.UserInput("Select Text File");

            if (fileId.ToLower() == "exit")
            {
                exit = true;
                return null;
            }

            if (!int.TryParse(fileId, out int fileIndex))
            {
                Console.WriteLine("Input Must Be Integer\n");
                Console.Beep();
                return null;
            }

            if (fileIndex < 1 || fileIndex > 4)
            {
                Console.WriteLine("Invalid File Selection\n");
                Console.Beep();
                Console.Beep();
                return null;
            }

            var fileInfo = files[fileIndex - 1];
            Console.WriteLine($"File Selected by you is : {fileInfo.Name}\n");

            return fileInfo;
        }

        public static List<FileInfo> ShowFiles()
        {
            var fileCount = 1;
            List<FileInfo> fileInfo = new List<FileInfo>();

            var path = $"{AppDomain.CurrentDomain.BaseDirectory}TextFiles";

            string[] files = Directory.GetFiles(path, "*.txt", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                fileInfo.Add(info);

                Console.WriteLine($"{fileCount++} : {info.Name}");

                if (fileCount == 4)
                    break;

                //fileCount++;
            }

            Console.WriteLine("\n[Type Exit for Exit]\n");


            return fileInfo;
        }
    }
}