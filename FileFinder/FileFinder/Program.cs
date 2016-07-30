using System;
using System.Collections.Generic;
using System.IO;

namespace FileFinder
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("please enter path : ");
            string inputPath = Console.ReadLine();
            Console.WriteLine("please enter string to search : ");
            string inputString = Console.ReadLine();
            List<string> filePaths =FindFile(inputPath, inputString);
            foreach (var file in filePaths)
            {
                FileInfo f = new FileInfo(file);
                long s = f.Length;
                Console.WriteLine("File Name :"+ FileName(file) + "   ,File length :" +s);
            }
        }

        public static List<string> FindFile(string dirPath, string inputString)
        {
            List<string> filePaths = new List<string>(Directory.GetFiles(@dirPath, "*.txt"));
            List<string> fileContains = new List<string>();

            
            foreach (var fileString in filePaths)
            {
                using (StreamReader sr = new StreamReader(fileString))
                {
                    string contents = sr.ReadToEnd();
                    if (contents.Contains(inputString))
                    {                        
                        fileContains.Add(fileString);
                    }
                    sr.Close();
                }
                               
            } 
            return fileContains;
        }

        private static string FileName(string dir)
        {
            char[] delimiterChars = { '/', '\\' };            
            string[] words = dir.Split(delimiterChars);
            return words[words.Length - 1];
        }
    }
}
