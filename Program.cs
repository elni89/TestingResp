using System;
using System.Data.SqlClient;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("==== MENU ====");
                Console.WriteLine("(a) Se alla produkter i databaden");
                Console.WriteLine("(b) Se lager status för alla spelen");
                Console.WriteLine("(c) Se alla spel under kategorin action");
                Console.WriteLine("(d) Se alla spel under kategorin sport");
                Console.WriteLine("(e) Se alla spel under kategorin puzzle");
                Console.WriteLine("(f) Se alla spel under kategorin adveture");
                var val = Console.ReadLine().ToLower();

                if (val == "a" || val == "b" || val == "c" || val == "d" || val == "e" || val == "f")
                {
                    switch (val)
                    {
                        case "a":
                            DatabaseManagerAllproducts allproducts = new DatabaseManagerAllproducts();
                            allproducts.allProducts();
                            break;

                        case "b":
                            DatabaseManagerAllQuantity quantity = new DatabaseManagerAllQuantity();
                            quantity.quantity();
                            break;

                        case "c":
                            Console.WriteLine("du valde C");
                            break;

                        case "d":
                            Console.WriteLine("du vale D");
                            break;

                        case "e":
                            Console.WriteLine("du valde E");
                            break;

                        case "f":
                            Console.WriteLine("du vale F");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Du måste ange ett val");
                }

            }
        }
    }
}