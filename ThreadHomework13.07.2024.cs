class Program
{
    static void Main(string[] args)
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        using (FileStream f = new FileStream("file.txt", FileMode.Create))
        {
            using (StreamWriter w = new StreamWriter(f))
            {
                Parallel.For(a, b, i =>
                {
                    for(int j=1; j < 11; j++)                    
                      w.WriteLine($"{i} * {j} = {i * j}");
                    
                });
            }
        }
  
    }
}