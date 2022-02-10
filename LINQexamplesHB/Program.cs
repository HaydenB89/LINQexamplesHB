using System;
using System.Collections.Generic;
using System.Linq;  //dont foget to add this

namespace LINQexamplesHB {
    class Program {
        static void Main(string[] args) {

            int[] ints = new int[] {
            869,    842,    861,    672,    757,    144,    397,    110,    109,    111,
            104,    348,    551,    624,    141,    887,    792,    395,    281,    737,
            612,    740,    574,    313,    672,    404,    523,    507,    843,    164,
            233,    115,    338,    905,    378,    761,    169,    666,    354,    453,
            501,    469,    406,    948,    417,    149,    909,    334,    321,    645,
            370,    933,    483,    770,    681,    631,    108,    151,    726,    876,
            869,    464,    827,    678,    240,    971,    903,    709,    380,    246,
            733,    915,    503,    474,    445,    866,    152,    447,    560,    387,
            726,    314,    477,    523,    483,    452,    250,    966,    677,    442,
            841,    278,    406,    787,    710,    769,    570,    145,    555,    774
        };




            List<Customers> customers = new List<Customers>() {
                new Customers() {Id = 1, Name = "MAX", Sales = 1000},
                new Customers() {Id = 2, Name = "P&G", Sales = 2000},
                new Customers() {Id = 3, Name = "Microsoft", Sales = 3000},
                new Customers() {Id = 4, Name = "Amazon", Sales = 4000},
                new Customers() {Id = 5, Name = "Google", Sales = 5000}
            };

            List<Order> orders = new List<Order>() {
                new Order(){ Id = 1, Descriotion = "1st Order",
                            Total = 1000, CustomerId = 2},
                new Order(){ Id = 2, Descriotion = "2st Order",
                            Total = 2000, CustomerId = 5},
                new Order(){ Id = 3, Descriotion = "3st Order",
                            Total = 3000, CustomerId = 1}
            };

            var customerOrders = from o in orders
                                 join c in customers             //join like SQL
                                 on o.CustomerId equals c.Id     //DIFFERENT FRO SQL !! join on the FROM variable -(o) in this case
                                 orderby o.Total descending
                                 select new {
                                     o.Id,                       //SELECT shows the folloing from called 
                                     o.Descriotion,              // class (o. or c. in this case)
                                     Amount = o.Total,
                                     Customer = c.Name
                                 };
            foreach(var co in customerOrders) {
                Console.WriteLine($"{co.Id,-5}{co.Descriotion,-30}" +      //the numbers in the parameters are the 
                                  $"{co.Amount,7:c}{co.Customer,25}");     //characters length that space out the lines
            }

            var orderedCustomers = from c in customers
                                   orderby c.Sales descending
                                   select new {
                                       c.Name,
                                       c.Sales
                                   };
            foreach(var c in orderedCustomers) {
                Console.WriteLine($"{c.Name, -15} {c.Sales,15:c}");
            }

            int[] numbers = { 23, 28, 225, 35, 500, 22, 15,
                              -63, 7, 88, 53, -1, 12, 17 };

            Console.WriteLine($"Total is {numbers.Sum()}");

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
                Console.Write($"{n1} ");                                                                                                    
            }

            var querynbrs = from n in numbers                   //query mode starts with 'var' as SELECT and
                            where n < 200                        //is stated by '= from' (SQL adjacent)
                            orderby n
                            select n;

            int total = 0;
            foreach(int n in numbers) {
                if (n % 2 == 1) {
                    total += n;
                    Console.Write($"{n} ");
                }
            }
            Console.WriteLine($"Total is {total}");
        }
    }
}
