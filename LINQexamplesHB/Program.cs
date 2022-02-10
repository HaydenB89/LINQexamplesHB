using System;
using System.Linq;  //dont foget to add this

namespace LINQexamplesHB {
    class Program {
        static void Main(string[] args) {
            int[] numbers = { 23, 28, 225, 35, 500, 22, 15,
                              -63, 7, 88, 53, -1, 12, 17 };

            //MESSING AROUND\\
            int[] numLsThn200 = numbers
                                .Where(t => t < 200).ToArray();

            int[] numGrtThnEq50LsThnEql100 = numbers
                                .Where(nbr => nbr >= 50 && nbr <= 100).ToArray();


            //Done messing\\
            //notes below
            int[] numbers2 = numbers                             //Where is a method in LINQ, functions much like SQL
                                .Where(n => n % 2 == 1)          //create the variable on the left sideof the lamda(=>) use it on the right
                                .OrderByDescending(x => x)       // Again, much like SQL you can sort them with OrderBy
                                .ToArray();                          
            foreach (int n1 in numbers2) {                                                                      
                Console.WriteLine($"odd: {n1}");                                                                                                    
            }

            var querynbrs = from n in numbers                   //query mode starts with 'var' and
                            where n < 200                        //is stated by '= from' (SQL adjacent)
                            orderby n
                            select n;

            int total = 0;
            foreach(int n in numbers) {
                if (n % 2 == 1) {
                    total += n;
                    Console.WriteLine($"{n} ");
                }
            }
            Console.WriteLine($"Total is {total}");
        }
    }
}
