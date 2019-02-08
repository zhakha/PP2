using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        public static bool IsPoli(string s)
        {
            if (s.Length <= 2)
            {
                return true;
            }
            string t = Reverse(s);
            if (t == s)
            {
                return true;
            }
            return false;
        }
        public static string Reverse(string x)
        {
            char[] c = x.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:/Users/user/Desktop/PP2lab2/1.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string l = sr.ReadLine();
            if (IsPoli(l) == true)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
