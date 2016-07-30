using System;
using System.Collections.Generic;
using System.IO;

namespace Personnel
{
    class Program
    {
        static void Main()
        {
            string dir = "C:\\Users\\bashar\\Source\\Repos\\Assigment 2\\Personnel\\Personnel\\";
            ReadFile(dir + "file1.txt");
            ReadFile(dir + "file2.txt");
        }


        public static void ReadFile(string fileName)
        {
            List<string> result = new List<string>();
            using (FileStream stm = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                StreamReader reader = new StreamReader(stm);
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    result.Add(line);
                }                
                reader.Close();
            }
            foreach (var lin in result)
            {
                Console.WriteLine(lin);
            }
        }


    }
}
