using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\Desktop\PP2lab2\x.txt";
            string path1 = @"C:\Users\user\Desktop\PP2lab2\Task4";
            DirectoryInfo di = new DirectoryInfo(path1);
            FileInfo fi = new FileInfo(path);
            fi.CopyTo(path1 + @"\dublicate.txt", true);
            fi.Delete();
        }
    }
}