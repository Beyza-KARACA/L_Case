using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics
{
    class Program
    {
        public static int summation = 0;

        //1.4 Sum of numbers from 1 to n
        public static int Sum(int n)
        {
            summation = n * (n + 1) / 2;
            return summation;
        }

        //1.5 Sum of numbers from 1 to n
        //Sum_A-> Finding sums with the for loop
        public static int Sum_A(int n)
        {
            summation = 0;
            for (int i=1;i<=n;i++)
            {
                summation += i;
            }

            return summation;
        }

        //Sum_B-> Finding sums with the while loop
        public static int Sum_B(int n)
        {
            summation = 0;
            int i = 1;

            while(i<=n)
            {
                summation += i;
                i++;
            }

            return summation;
        }

        //Sum_C-> Finding sums with the LINQ
        public static int Sum_C(int n)
        {
            summation = 0;
            var numbers = new List<int> {  };

            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            summation = (from x in numbers select x).Sum();

            return summation;
        }

        static void Main(string[] args)
        {
            //1.2 Ascending Order (1-100)
            Console.WriteLine("Ascending Order");
            for (int i = 1; i <= 100; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\n");

            //1.3 Descending Order(1-100)
            Console.WriteLine("Descending Order");
            for (int i = 100; i >=1 ; i--)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\n\nPlease enter the number n to calculate the sum of numbers from 1 to n---> ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Sums-->" + Sum(n));
            Console.WriteLine("Sums with the for loop-->"+Sum_A(n));
            Console.WriteLine("Sums with the while loop-->" + Sum_B(n));
            Console.WriteLine("Sums with the LINQ-->" + Sum_C(n));

            Console.WriteLine("\nPress a button to exit the console");
            Console.ReadKey();
        }
    }
}
