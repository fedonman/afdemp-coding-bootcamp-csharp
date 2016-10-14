using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_05
{
    class Program
    {
        //Enumeration defining Gender
        public enum Gender
        {
            Male = 100,
            Female = 200
        }
        //Parent class Animal
        public abstract class Animal
        {
            public int Age { get; protected set; }
            public string Name;
            public Gender Gender;
            protected string sound;

            //Constructor of Animal
            public Animal(string name, int age, Gender Gender)
            {
                Name = name;
                Age = age;
                this.Gender = Gender;
            }

            public string MakeSound()
            {
                return sound;
            }
        }

        //Child class Dog inherits from Animal
        public class Dog : Animal
        {
            //Constructor of Dog inherits constructor of Animal
            public Dog(string name, int age, Gender gender) : base(name, age, gender)
            {
                //and then does Dog's specific stuff
                sound = "wuf wuf";
            }
        }

        //Same logic as Dog
        public class Cat : Animal
        {
            public Cat(string name, int age, Gender gender) : base(name, age, gender)
            {
                sound = "meow!";
            }
            
        }

        static void Main(string[] args)
        {
            //Array containing objects of parent class Animal
            Animal[] animals = new Animal[]
            {
                new Dog("Lucy", 5, Gender.Female),
                new Dog("Tom", 1, Gender.Male),
                new Cat("Neda", 4, (Gender)200)
            };
            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine(animals[i].Name + " who is " + animals[i].Gender + " says \"" + animals[i].MakeSound() + "\"");
            }

            Console.ReadKey();
        }
    }
}
