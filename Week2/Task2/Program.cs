using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        public static bool IsPrime(int x)
        {
            if (x <= 1)
            {
                return false;
            }
            for(int i=2; i<=Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            string l=System.IO.File.ReadAllText(@"C:\Users\user\Desktop\PP2lab2\a.txt");
            int[] a = new int[l.Length/2+1];
            a = l.Split(' ').Select(int.Parse).ToArray();
            for(int i=0; i<a.Length; i++)
            {
                if(IsPrime(a[i]) == true)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\Users\user\Desktop\PP2lab2\b.txt", true))
                    {
                        sw.Write(a[i] + " ");
                    }
                }
            }
        }
    }
}
