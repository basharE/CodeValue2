using System;
using System.Collections.Generic;
using System.IO;

namespace Personnel
{
    class Program
    {
        static void Main()
        {
            //Absolutes path are rarely a good idea.. for instance, there's no such folder on my computer :)
            string dir = "C:\\Users\\bashar\\Source\\Repos\\Assigment 2\\Personnel\\Personnel\\";
            //Bug: Since you did not handle exceptions and the path does not exist, the app crashed
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
                /**Note that this approach to Close the reader only at the end is dangreous, since an exception within the body loop can lead to a leaked resource
         * Consider this:
         * using(var fs = ...)
           {
              using(var sr = ...)
               {
                   //Ccode
               }
           }

         * https://msdn.microsoft.com/en-us/library/3bwa4xa9(v=vs.110).aspx
         */
                reader.Close();
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
