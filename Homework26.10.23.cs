using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Homework12._10._23
{
    public class Worker
    {
        private string name;
        private int age;
        private string position;



        public Worker()
        {
            name = "";
            age = 0;
            position = "";
        }
        public Worker(string name, int age, string position)
        {
            this.name = name;
            this.age = age;
            this.position = position;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

  
        public string Position
        {
            get { return position; }
            set { position = value; }
        }

      
        public void Print()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Возраст: {age} лет");
            Console.WriteLine($"Должность: {position}");
            Console.WriteLine();

        }
        public override string ToString()
        {
            return $"Имя: {name} " + $"Возраст: {age} лет " + $"Должность: {position} ";
        }
    }

    class ArrayWorker
    {
        private List<Worker> AW;
        public ArrayWorker()
        {
            AW = new List<Worker>();
        }
        public void Add(Worker worker)
        {
            AW.Add( worker );
        }
        public void Del(int index)
        {
            AW.RemoveAt( index );
        }
        public void Print(string msg ="")
        {
            Console.WriteLine(msg);
            foreach (Worker worker in AW)
                worker.Print();
            

        }


        public void SaveToFileTxt(string filename) //!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {

            using(FileStream f=new FileStream(filename, FileMode.Create))
            {
                using(StreamWriter sw=new StreamWriter(f))
                {
                    foreach (Worker worker in AW)
                        sw.WriteLine(worker.ToString());
                }
            }
        }
        public void ReadFromFileTxt(string filename)
        {
            using(FileStream f = new FileStream(filename, FileMode.Open))
            {
                if(AW.Count!=0)
                    AW.Clear();
                using (StreamReader sr = new StreamReader(f))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                    
                        string[]parts = line.Split(' ');
                        //1 3 6

                        AW.Add(new Worker(parts[1], Convert.ToInt32(parts[3]), parts[6]));

                    }
                }
            }
        }
        public void SaveToFileBin(string filename)
        {
            using (FileStream f = new FileStream(filename, FileMode.Create))
            {
                using(BinaryWriter sr = new BinaryWriter(f))
                {
                    foreach (Worker worker in AW)
                    {
                        sr.Write(worker.Name);
                        sr.Write(worker.Age);
                        sr.Write(worker.Position);
                    }
                }
            }
        }
        public void ReadFromFileBin(string filename)
        {
            using (FileStream f = new FileStream(filename, FileMode.Open))
            {
                using(BinaryReader br = new BinaryReader(f))
                {
                    if (AW.Count != 0)
                        AW.Clear();
                    
                  

                    if (AW.Count != 0)
                        AW.Clear();
                    while (br.PeekChar() > -1)
                    {
                        string name = br.ReadString();
                        int age = br.ReadInt32();
                        string position = br.ReadString();

                        AW.Add(new Worker(name, age, position));
                    }

                }
            }
        }

    }

    internal class Program
    {




        static void Main(string[] args)
        {
           

            //5
            ArrayWorker workers = new ArrayWorker();
            workers.Add(new Worker("sss",12,"sss"));
            workers.Add(new Worker("dddd", 13,"dddd"));
            workers.Add(new Worker("fffff", 13, "jkkkk"));
            workers.Print("=>");
            //workers.Del(1);
            workers.Print("=>");
            workers.SaveToFileTxt("file.txt");
            Console.WriteLine("--------------------");
            workers.ReadFromFileTxt("file.txt");
            workers.Print("=>");
            Console.WriteLine("-------------------------BIIIIN");
            workers.SaveToFileBin("file.bin");
            workers.ReadFromFileBin("file.bin");
            workers.Print();

        }
    }
}
