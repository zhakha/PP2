using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            // n - is the size of our array
            int[] a = new int[n];
            string s = Console.ReadLine();
            a = s.Split(' ').Select(int.Parse).ToArray();
            // we make the array with string s and call it how array- a[]
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
                Console.Write(a[i] + " ");
            }
            // in this cycle program will write the numbers with repeating
        }
    }
}