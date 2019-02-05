using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
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
        //Firstly, we must create a new function to find prime numbers
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            // n - is the size of our array
            int[] a = new int[n];
            string s = Console.ReadLine();
            a = s.Split(' ').Select(int.Parse).ToArray();
            // we make the array with string s and call it how array- a[]
            int c = 0;
            for (int i=0; i<a.Length; i++)
            {
                if (IsPrime(a[i]) == true)
                {
                    c++;
                }
            }
            Console.WriteLine(c);
            // c will give us the count of prime numvers in our array
            for (int i = 0; i < a.Length; i++)
            {
                if (IsPrime(a[i]) == true)
                {
                    Console.Write(a[i] + " ");
                }
            }
            // in this cycle program will write the prime numbers with using the function IsPrime
        }
    }
}
