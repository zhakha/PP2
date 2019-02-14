using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    enum FSIMode
    {
        Folder = 0,
        File = 1
    }
    class Layer
    {
        int selectedIndex;
        public DirectoryInfo[] Directories
        {
            get;
            set;
        }
        public FileInfo[] Files
        {
            get;
            set;
        }
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                if (value < 0) selectedIndex = Directories.Length + Files.Length - 1;
                else if (value > Directories.Length + Files.Length - 1) selectedIndex = 0;
                else selectedIndex = value;
            }
        }
        void SelectedColor(int i)
        {
            if (i == SelectedIndex)
                Console.BackgroundColor = ConsoleColor.Red;
            else
                Console.BackgroundColor = ConsoleColor.Black;
        }
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Directories.Length; i++)
            {
                SelectedColor(i);
                Console.WriteLine((i + 1) + ". " + Directories[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < Files.Length; i++)
            {
                SelectedColor(i + Directories.Length);
                Console.WriteLine((i + Directories.Length + 1) + ". " + Files[i].Name);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\user\Desktop\PP2lab3");
            Layer l = new Layer
            {
                Directories = di.GetDirectories(),
                Files = di.GetFiles(),
                SelectedIndex = 0
            };
            Stack<Layer> history = new Stack<Layer>();
            history.Push(l);
            bool x = false;
            FSIMode md = FSIMode.Folder;
            while (!x)
            {
                if (md == FSIMode.Folder)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo ifkey = Console.ReadKey();
                if (ifkey.Key == ConsoleKey.UpArrow)
                    history.Peek().SelectedIndex--;

                else if (ifkey.Key == ConsoleKey.DownArrow)
                    history.Peek().SelectedIndex++;

                else if (ifkey.Key == ConsoleKey.Enter)
                {
                    int open = history.Peek().SelectedIndex;
                    if (open < history.Peek().Directories.Length)
                    {
                        DirectoryInfo dd = history.Peek().Directories[open];
                        Layer lay = new Layer
                        {
                            Directories = dd.GetDirectories(),
                            Files = dd.GetFiles(),
                            SelectedIndex = 0
                        };
                        history.Push(lay);
                    }
                    else
                    {
                        md = FSIMode.File;
                        StreamReader sr = new StreamReader(history.Peek().Files[open - history.Peek().Directories.Length].FullName);
                        string s = sr.ReadToEnd();
                        sr.Close();
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Clear();
                        Console.WriteLine(s);
                    }
                }

                else if (ifkey.Key == ConsoleKey.Backspace)
                {
                    if (md == FSIMode.Folder)
                    {
                        if (history.Count > 1)
                            history.Pop();
                    }
                    else
                        md = FSIMode.Folder;
                }


                else if (ifkey.Key == ConsoleKey.Delete)
                {
                    int del = history.Peek().SelectedIndex;
                    int z = del;
                    if (del < history.Peek().Directories.Length) { history.Peek().Directories[del].Delete(true); }
                    else { history.Peek().Files[del - history.Peek().Directories.Length].Delete(); }
                    history.Pop();

                    if (history.Count() == 0)
                    {
                        Layer lay = new Layer
                        {
                            Directories = di.GetDirectories(),
                            Files = di.GetFiles(),
                            SelectedIndex = z--
                        };
                        history.Push(lay);
                    }

                    else
                    {
                        int i = history.Peek().SelectedIndex;
                        DirectoryInfo dd = history.Peek().Directories[i];
                        Layer ly = new Layer
                        {
                            Directories = dd.GetDirectories(),
                            Files = dd.GetFiles(),
                            SelectedIndex = z--
                        };
                        history.Push(ly);
                    }
                }


                else if (ifkey.Key == ConsoleKey.F2)
                {
                    Console.Clear();
                    int rename = history.Peek().SelectedIndex;
                    int i = rename;
                    string name, fname;
                    int selMode;

                    if (rename < history.Peek().Directories.Length)
                    {
                        name = history.Peek().Directories[rename].Name;
                        fname = history.Peek().Directories[rename].FullName;
                        selMode = 1;
                    }
                    else
                    {
                        name = history.Peek().Files[rename - history.Peek().Directories.Length].Name;
                        fname = history.Peek().Files[rename - history.Peek().Directories.Length].FullName;
                        selMode = 2;
                    }

                    string path = fname.Remove(fname.Length - name.Length);
                    Console.WriteLine("Please, enter the new name with it extension:");
                    string newname = Console.ReadLine();

                    if (selMode == 1) { new DirectoryInfo(history.Peek().Directories[rename].FullName).MoveTo(path + newname); }
                    else { new FileInfo(history.Peek().Files[rename - history.Peek().Directories.Length].FullName).MoveTo(path + newname); }
                    history.Pop();


                    if (history.Count == 0)
                    {
                        Layer lay = new Layer
                        {
                            Directories = di.GetDirectories(),
                            Files = di.GetFiles(),
                            SelectedIndex = i
                        };
                        history.Push(lay);
                    }
                    else
                    {
                        rename = history.Peek().SelectedIndex;
                        DirectoryInfo dir = history.Peek().Directories[rename];
                        Layer ly = new Layer
                        {
                            Directories = dir.GetDirectories(),
                            Files = dir.GetFiles(),
                            SelectedIndex = i
                        };
                        history.Push(ly);
                    }
                }


                else if (ifkey.Key == ConsoleKey.Escape)
                {
                    x = true;
                }
            }

        }
    }
}