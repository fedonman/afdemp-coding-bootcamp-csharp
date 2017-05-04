using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseZoo
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
        public abstract class Animal : IComparable<Animal>
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

            public int CompareTo(Animal other)
            {
                return Age.CompareTo(other.Age);
            }
        }

        public class Monkey : Animal
        {
            //Constructor of Monkey inherits constructor of Animal
            public Monkey(string name, int age, Gender gender) : base(name, age, gender)
            {
                //and then does Monnkey's specific stuff
                sound = "oug oug";
            }
        }

        //Child class Lion inherits from Animal
        public class Lion : Animal
        {
            //Constructor of Lion inherits constructor of Animal
            public Lion(string name, int age, Gender gender) : base(name, age, gender)
            {
                //and then does Lion's specific stuff
                sound = "AAARrrrrr";
            }
        }

        //Same logic
        public class Cat : Animal
        {
            public Cat(string name, int age, Gender gender) : base(name, age, gender)
            {
                sound = "meow!";
            }
            
        }

        public class Zoo
        {
            List<Animal> animals;
            public string Name { get; private set; }

            public Zoo(string name)
            {
                Name = name;
                animals = new List<Animal>();
            }

            public void Add(Animal a)
            {
                animals.Add(a);
            }

            public string PrintAnimals()
            {
                string result = "";
                foreach (Animal a in animals)
                {
                    result += $"{a.Name} is a {a.GetType()} of age {a.Age} says {a.MakeSound()}\n";
                }
                return result;
            }

            public void SortAnimals()
            {
                animals.Sort();
            }
        }

        static void Main(string[] args)
        {
            // Cannot create abstract classes
            // Animal a = new Animal("Peter", 5, Gender.Male);
            
            // Create the zoo
            Zoo zoo = new Zoo("Attiko Parko");

            // Add some animals
            zoo.Add(new Lion("Lucy", 5, Gender.Female));
            zoo.Add(new Lion("Tom", 1, Gender.Male));
            zoo.Add(new Cat("Neda", 4, (Gender)200));
            zoo.Add(new Monkey("Jim", 10, Gender.Male));

            // Print, Sort, and print again
            Console.WriteLine(zoo.PrintAnimals());
            zoo.SortAnimals();
            Console.WriteLine(zoo.PrintAnimals());

            Console.ReadKey();
        }
    }
}
