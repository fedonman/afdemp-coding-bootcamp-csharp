using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_02
{
    class Program
    {
        public class Coffee
        {
            public enum CoffeeType
            {
                Small = 100,
                Normal = 150,
                Double = 300
            }
            public CoffeeType Type { get; private set; }
            
            public Coffee(CoffeeType type)
            {
                Type = type;
            }

            public string PrintInfo()
            {
                return $"{Type} coffee is {(int)Type} ml.";
            }
        }

        public class Order {
            private List<Coffee> items = new List<Coffee>();

            public void Add(Coffee coffee)
            {
                items.Add(coffee);
            }

            public double CalculateCost()
            {
                double cost = 0;
                foreach (Coffee c in items)
                {
                    switch(c.Type)
                    {
                        case Coffee.CoffeeType.Small:
                            cost += 5;
                            break;
                        case Coffee.CoffeeType.Normal:
                            cost += 10;
                            break;
                        case Coffee.CoffeeType.Double:
                            cost += 15;
                            break;
                        default:
                            break;
                    }
                }
                return cost;
            }
        }

        static void Main(string[] args)
        {
            Coffee c1 = new Coffee(Coffee.CoffeeType.Small);
            Console.WriteLine(c1.PrintInfo());
            Order order = new Order();
            order.Add(c1);
            order.Add(new Coffee(Coffee.CoffeeType.Double));
            Console.WriteLine(order.CalculateCost());
            Console.ReadKey();
        }
    }
}
