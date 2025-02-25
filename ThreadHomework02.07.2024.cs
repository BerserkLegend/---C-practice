
class Program
{
    static void Main()
    {
        //3

        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());
        Thread[]thread = new Thread[c];
        for (int j = 0; j < thread.Length; j++)
        {
            thread[j] = new Thread(() =>
            {
                for (int i = a; i <= b; i++)
                {
                    Console.WriteLine($"Thread num:{Thread.CurrentThread.ManagedThreadId},{i}");
                    Thread.Sleep(30);
                }
                Console.WriteLine("That`s finish");
            });
        }
        foreach(Thread t in thread)
        {
            t.Start();


        }
        foreach (Thread t in thread)
        {
            t.Join();
        }



        //2
        /* int a = Convert.ToInt32(Console.ReadLine());
         int b = Convert.ToInt32(Console.ReadLine());
         Thread thread = new Thread(()=>{
             for (int i = a; i <= b; i++)
             {
                 Console.WriteLine(i);
                 Thread.Sleep(30); 
             }
             Console.WriteLine("That`s finish");

         });

         thread.Start();
         thread.Join();
 */


        //1
        /* Thread thread = new Thread(() => {
             for (int i = 0; i <= 50; i++)
             {
                 Console.WriteLine(i);
                 Thread.Sleep(30);
             }
             Console.WriteLine("That`s finish");

         });

         thread.Start();
         thread.Join();*/
    }


}