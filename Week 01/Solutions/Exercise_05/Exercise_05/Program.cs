using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_05
{
    class Program
    {
        public abstract class Animal
        {
            public int Age { get; protected set; }
            public string Name;
            public int Gender;
            protected string sound;

            public Animal(string name, int age, int gender)
            {
                Name = name;
                Age = age;
                Gender = gender;
            }

            public string MakeSound()
            {
                return sound;
            }
        }

        public class Dog : Animal
        {
            public Dog(string name, int age, int gender) : base(name, age, gender)
            {
                sound = "wuf wuf";
            }
        }

        public class Cat : Animal
        {
            public Cat(string name, int age, int gender) : base(name, age, gender)
            {
                sound = "meow!";
            }
            
        }

        static void Main(string[] args)
        {
            Animal[] animals = new Animal[]
            {
                new Dog("Lucy", 5, 1),
                new Dog("Tom", 1, 0),
                new Cat("Neda", 4, 1)
            };
            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine(animals[i].Name + " says \"" + animals[i].MakeSound() + "\"");
            }

            Console.ReadKey();
        }
    }
}
