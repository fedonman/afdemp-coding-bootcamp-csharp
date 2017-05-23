using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseUtilities
{
    public class Complex
    {
        // Real part
        // private variable
        private double a;
        // exposed by public property
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

        //Public property with read-only access
        public double Norm
        {
            get { return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)); }
        }

        public static double GetDouble()
        {
            return 2;
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
            double r = this.Real + x.Real;
            double i = this.Imaginary + x.Imaginary;
            Complex z = new Complex(r, i);
            return z;
        }

        // Class Method. Adds parameter Complex object
        // to this Complex object
        public void AddSelf(Complex x)
        {
            this.a += x.Real;
            this.b += x.Imaginary;
        }

        // Class operator +. Adds the two Complex objects
        // and return a new Complex object
        // Very powerful because enables chaining like c1 + c2 + c3
        public static Complex operator +(Complex x, Complex y)
        {
            return new Complex(x.a + y.a, x.b + y.b);
        }

        // Class operator -
        public static Complex operator -(Complex x, Complex y)
        {
            return new Complex(x.a - y.a, x.b - y.b);
        }

        public static Complex operator *(Complex x, Complex y)
        {
            return new Complex(x.Real * y.Real - x.Imaginary * y.Imaginary, x.Real * y.Imaginary + x.Imaginary + y.Real);
        }

        public static Complex operator /(Complex x, Complex y)
        {
            return new Complex((x.Real * y.Real + x.Imaginary * y.Imaginary) / (Math.Pow(y.Real, 2) + Math.Pow(y.Imaginary, 2)), (x.Imaginary * y.Real - x.Real * y.Imaginary) / (Math.Pow(y.Real, 2) + Math.Pow(y.Imaginary, 2)));
        }

        // Class operator ==
        public static bool operator ==(Complex x, Complex y)
        {
            if (x.Real == y.Real && x.Imaginary == y.Imaginary)
            {
                return true;
            }
            return false;
        }

        // Class operator !=
        public static bool operator !=(Complex x, Complex y)
        {
            if (x.Real != y.Real || y.Imaginary != x.Imaginary)
            {
                return true;
            }
            return false;
        }

        // Override default ToString() method to allow
        // customized output.
        // All lines return the same result
        public override string ToString()
        {
            //return this.Real + " + " + this.Imaginary + "i";
            //return String.Format("{0} + {1}i", this.Real, this.Imaginary);
            return $"{this.Real} + {this.Imaginary} i";
        }
    }
}
