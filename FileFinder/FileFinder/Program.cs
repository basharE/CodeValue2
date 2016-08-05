using System;
using System.Collections.Generic;
using System.IO;

namespace FileFinder
{
    class Program
    {
        static void Main()//I think this method is missing something..
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
            //Bug: What about non txt files?
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
                    sr.Close();//Redundant, since reader will be closed when the using statement goes out of scope.. 
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
