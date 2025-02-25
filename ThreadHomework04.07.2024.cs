

internal class Program
{
    static void Main(string[] args)
    {
        int[] mass = new int[10000];
        int lmax =0;
        int lmin =0;
        int lavg =0;
        Func<int> findmax = () =>
        {
            int max = -1;
            foreach (int i in mass)
            {
                if (i > max)
                    max = i;

            }
            return max;

        };
        Func<int> findmin = () =>
        {
            int min = mass[0];
            foreach (int i in mass)
            {
                if (i <min)
                    min = i;

            }
            return min;
        };
        Func<int> findavg = () =>
        {
            int sum = 0;

            foreach (int i in mass)
            {
                sum += i;

            }
            sum = sum / mass.Length;
            return sum;

        };


        Random random = new Random();
        for(int i =0; i < mass.Length; i++) {
            mass[i] = random.Next(0,10000);
        }
        Thread thread = new Thread(()=>{ lmax = findmax(); });
        Thread thread1 = new Thread(() => { lmin = findmin(); });
        Thread thread2 = new Thread(() => {  lavg = findavg(); });
        thread.Start();
        thread1.Start();
        thread2.Start();


        thread.Join();
        thread1.Join();
        thread2.Join();
        int min = lmin;
        int max = lmax;
        int avg = lavg;

        Thread thread3 = new Thread(() =>
        {
            Console.WriteLine($"MIN:{min}, MAX:{max}, AVG:{avg}");
            using (FileStream fileStream = new FileStream("FILE.txt", FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine($"MIN:{min}, MAX:{max}, AVG:{avg}");
                
            }
        });
        thread3.Start();
        thread3.Join();



    }
    
}