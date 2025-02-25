
internal class Program
{
    static void Main(string[] args)
    {
        //1   .   2 
        Console.WriteLine(DateTime.Now);
        Task task1 = new Task(() => { func(1, 100); });
      
        Task task2 = Task.Factory.StartNew(() => func(1,400));
        Task task3 = Task.Run(() => func());

        task1.Start();
        Task.WaitAll(task1,task2,task3);

    }
    //1
    public static void func()
    {
        for(int i = 0; i < 1000; i++)
        {
            Console.WriteLine(i);
        }
    }
    //2
    public static void func(int a, int b)
    {
        for (int i = a ; i<b; i++)
        {
            Console.WriteLine(i);
        }
    }
}
