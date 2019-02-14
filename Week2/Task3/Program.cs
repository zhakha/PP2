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
        static void Open(DirectoryInfo target, int a)
        {
            FileInfo[] files = target.GetFiles();
            DirectoryInfo[] directories = target.GetDirectories();

            foreach (DirectoryInfo directory in directories)
            {
                for (int i = 0; i < a; ++i)
                    Console.Write("      ");
                Console.WriteLine("     " + directory.Name);
                Open(directory, a + 5);
            }
            foreach (FileInfo file in files)
            {
                for (int i = 0; i < a; ++i)
                    Console.Write("    ");
                Console.WriteLine("     " + file.Name);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo path = new DirectoryInfo(@"C:/Users/user/Desktop/ICT");
            Console.Write(path.Name);
            Console.WriteLine("     ");
            Open(path, 0);
            Console.ReadKey();
        }
    }
}