using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            //Firstly, we assign the size of our array, how n
            string[] arr = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arr[i]);
            }
            //this cycle do array with numbers in our string
            int m = n * 2;
            int[] b = new int[m];
            //in second array we double previous size and call it m
            for (int i = 0; i < n; i++)
            {
                b[2 * i] = a[i];
                b[2 * i + 1] = a[i];
            }
            //this cycle is the main part of our program, we give the formula of array, where every element is repeated
            for (int i = 0; i < m; i++)
            {
                Console.Write(b[i] + " ");
            }
            //and our program give us the repeated numbers 
        }
    }
}