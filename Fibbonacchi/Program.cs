using System;

namespace Fibbonacchi
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] store = new int[n + 1];
            CalcFib(n, store);
            Console.WriteLine(store[n]);
        }
        static int CalcFib(int n, int[] store)
        {
            if(n == 0)
            {
                return 0;
            }
            else if( n== 1 || n == 2)
            {
                store[n] = 1;
                return 1;
            }
            if(store[n] != 0)
            {
                return store[n];
            }
            
            store[n] = CalcFib(n - 1, store) + CalcFib(n - 2, store);
            return store[n];
        }
    }
}
