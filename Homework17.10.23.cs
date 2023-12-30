using System;

namespace Homework12._10._23
{
    //2
    delegate double Operation(double x, double y);



    class Calculator
    {
        public double Add(double x, double y) 
        { 
        
        return x + y;
        }
        public double Sub(double x, double y)
        {

            return x - y;
        }
        public static double Div(double x, double y)
        {
            return x / y;
        }
        public static double Mult(double x, double y)
        {
            return x * y;
        }

    }
    internal class Program
    {
       


        
        static void Main(string[] args)
        {
           

            Operation operation;
            bool IsExit = false;
            bool IsReapet = false;
            int a = 0, b = 0;
            int choose = 0;
            Calculator calc = new Calculator();
            while (!IsExit)
            {
                if (!IsReapet)
                {
                    Console.WriteLine("введите два числа:");
                    a = Convert.ToInt32(Console.ReadLine());
                    b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("выберите какую операцию сделать:");
                    Console.WriteLine("1.+ 2.- 3./ 4.* 5.EXIT");
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    while (choose < 1 || choose > 5)
                    {
                        Console.WriteLine("введите еще раз что в хотите обрать");
                        Console.WriteLine("1.+ 2.- 3./ 4.* 5.EXIT");
                        choose = Convert.ToInt32(Console.ReadLine());
                        IsReapet = false;
                    }
                }
                switch (choose)
                {
                    case 1:
                        operation = calc.Add;
                        Console.WriteLine(operation(a, b));
                        break;
                    case 2:
                        operation = calc.Sub;
                        Console.WriteLine(operation(a, b));
                        break;
                    case 3:
                        operation = Calculator.Div;
                        Console.WriteLine(operation(a, b));
                        break;
                    case 4:
                        operation = Calculator.Mult;
                        Console.WriteLine(operation(a, b));
                        break;
                    case 5:
                        IsExit = true;
                        break;
                    default:
                        IsReapet = true;
                        break;
                        
                }


            }
        }
    }
}
