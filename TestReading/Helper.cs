using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReading
{
    public class Helper
    {
        public static readonly Func<string, string> UserInput = (string msg) =>
        {
            Console.WriteLine($"{msg}\n");
            return Console.ReadLine();
        };


        public static Func<string, string, bool> CompareFiles = (string f1, string f2) =>
        {
            byte[] file1 = System.IO.File.ReadAllBytes(f1);
            byte[] file2 = System.IO.File.ReadAllBytes(f2);

            if (file1.Length != file2.Length) return false;



            for (int i = 0; i < file1.Length; i++)
            {
                if (file1[i] != file2[i])
                {
                    return false;
                }
            }
            return true;

        };
    }
}
