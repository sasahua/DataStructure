using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(Fib2(0));
            System.Console.WriteLine(Fib2(1));
            System.Console.WriteLine(Fib2(2));
            System.Console.WriteLine(Fib2(3));
            System.Console.WriteLine(Fib2(4));
            System.Console.WriteLine(Fib2(5));
            

        }

        //递归方式实现斐波那契
        static int Fib1(int n)
        {
            if(n<=1)return n;
            return Fib1(n-1) + Fib1(n-2);
        }

        static int Fib2(int n)
        {
            if(n<=1)return n;
            int first = 0;
            int second = 1;
            for (int i = 0; i < n-1; i++)
            {
                int sum = first + second;
                first = second;
                second = sum;
            }
            return second;
        }
    }
}

