using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_01
{
    class Program
    {
        public class Complex
        {
            // Real part
            private double a;
            public double Real
            {
                get { return a; }
                set { a = value; }
            }

            // Imaginary part
            private double b;
            public double Imaginary
            {
                get { return b; }
                set { b = value; }
            }

            // Constructors
            public Complex()
            {
                a = 0;
                b = 0;
            }
            public Complex(double x)
            {
                a = x;
                b = 0;
            }
            public Complex(double x, double y)
            {
                a = x;
                b = y;
            }

            // Static Method. Returns a new Complex object.
            public static Complex Add(Complex x, Complex y)
            {
                double r = x.Real + y.Real;
                double i = x.Imaginary + y.Imaginary;
                return new Complex(r, i);
            }

            // Class Method. Adds this Complex object
            // with parameter Complex object and returns
            // a new Complex object.
            public Complex Add(Complex x)
            {
                double r = this.a + x.Real;
                double i = this.Imaginary + x.Imaginary;
                Complex z = new Complex(r, i);
                return z;
            }

            // Class operator +. Adds the two Complex objects
            // and return a new Complex object
            public static Complex operator +(Complex x, Complex y)
            {
                return new Complex(x.a + y.a, x.b + y.b);
            }
            
            // Override default ToString() method to allow
            // customized output.
            public override string ToString() {
                return $"{this.Real} + {this.Imaginary} i";
            }
        }

        static void Main(string[] args)
        {
            //Create 3 sample Complex objects
            Complex z1 = new Complex(5);
            Complex z2 = new Complex(2, 10);
            Complex z3 = new Complex(1, 1);

            //Addition with different implementations
            Complex sum1 = z1.Add(z2);
            Complex sum2 = Complex.Add(z1, z2);
            Complex sum3 = z1 + z2;

            //Print results
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);

            //We can chain functions and operators!
            Complex sum4 = z1.Add(z2).Add(z3);
            Complex sum5 = Complex.Add(z1, z2).Add(z3);
            Complex sum6 = z1 + z2 + z3;

            //Print results
            Console.WriteLine(sum4);
            Console.WriteLine(sum5);
            Console.WriteLine(sum6);

            Console.ReadKey();
        }
    }
}
