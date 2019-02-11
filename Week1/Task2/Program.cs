using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        public string name;
        public string id;
        public int year;
        //Firstly, we define the our main values

        public Student(string name1, string id1)
        {
            name = name1;
            id = id1;
            year = 0;
        }
        //we create constructor, which the constant name and id

        public string AccessName()
        {
            return name;
        }

        public string AccessId()
        {
            return id;
        }
        //in this functions always return constant name and id
        public void Show(Student a)
        {
            year++;
            Console.WriteLine(a.AccessName() + " " + a.AccessId() + " " + year);
        }
        //where, this function is performed, it give us name, id and year increases one more
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name: ");
            string n = Console.ReadLine();
            Console.WriteLine("ID: ");
            string i = Console.ReadLine();
            //in this lines we give some name and id
            Student a = new Student(n, i);
            //we use the metod, that give us the result with using our name and id
            Student b = new Student("Messi", "18BD240697");
            //this values the constant
            a.Show(a);
            b.Show(b);
            a.Show(a);
            b.Show(b);
            //how more we call the function show, then year increases for one
        }
    }
}