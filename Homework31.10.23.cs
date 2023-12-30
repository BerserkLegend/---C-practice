using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework31._10._23
{
    class QueueRing<T>
    {
        List<T> Q;
        int maxCount;
        public QueueRing(int maxCount)
        {
            Q = new List<T>(maxCount);
        }
        public void Clear()
        {
            Q.Clear();
        }
        public bool IsEmpty()
        {
            return Q.Count == 0;
        }
        public void Move()
        {
            T obj;
            obj = Q[0];
            Q.RemoveAt(0);
            Q.Add(obj);
        }
        public void Add(T item)
        {
            Q.Add(item);    
        }
        public T Pop()
        {
            T obj;
            obj = Q[0];
            Q.RemoveAt(0);
            return obj;
        }
        public void Print(string msg="")
        {
            Console.WriteLine(msg+" Queue: ");
            foreach(T item in Q)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            QueueRing<int> Q = new QueueRing<int>(4);
            Q.Add(10);
            Q.Add(20);
            Q.Add(30);
            Q.Add(40);
            Q.Print();
            Q.Move();
            Q.Print();
            Console.WriteLine( Q.Pop());
            Q.Print();

        }
    }
}
