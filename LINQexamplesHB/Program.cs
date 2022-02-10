using System;

namespace LINQexamplesHB {
    class Program {
        static void Main(string[] args) {
            int[] numbers = { 23, 28, 225, 35, 500, 22, 15,
                              -63, 7, 88, 53, -1, 12, 17 };
            int total = 0;
            foreach(int n in numbers) {
                if (n % 2 == 1) {
                    total += n;
                    Console.WriteLine($"{n} ");
                }
            }
            Console.WriteLine(total);
        }
    }
}
