using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Program
    {
        static public string File(string x)
        {
            string[] files = Directory.GetFiles(x);
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
            string[] dirs = Directory.GetDirectories(x);
            foreach (string dir in dirs)
            {
                Console.WriteLine(Path.GetFileName(dir));
                if (Directory.Exists(dir))
                {
                    return File(dir);
                }
                else
                {
                    return File(x);
                }
            }
            return " ";
        }
        public static void Main()
        {
            {
                string targetDirectory = @"C:\Users\user\Desktop\ICT";
                File(targetDirectory);   
            }
        }
    }
}