using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            MathProxy proxy = new MathProxy();

            Console .WriteLine($"118 + 33 = {proxy.Add(118,33)}");
            Console.WriteLine($"118 - 33 = {proxy.Sub(118, 33)}");
            Console.WriteLine($"118 * 33 = {proxy.Mul(118, 33)}");
            Console.WriteLine($"118 / 33 = {proxy.Div(118, 33)}");
            Console.WriteLine($"x^2 + y^2 = {proxy.Pitagora(118, 33)}");

            Console.ReadKey();
        }
    }

    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
        double Pitagora(double x, double y);
    }

    class Math : IMath
    {
        public double Add(double x, double y) 
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x*y;
        }

        public double Div(double x, double y)
        {
            return x/y;
        }

        public double Pitagora(double x, double y)
        {
            return Mul(x,x)+Mul(y,y);
        }
    }

    class MathProxy : IMath
    {
        private Math _math = new Math();
        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }

        public double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }

        public double Mul(double x, double y)
        {
            return _math.Mul(x, y);
        }

        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }

        public double Pitagora(double x, double y)
        {
            return _math.Pitagora(x, y);
        }
    }
}
