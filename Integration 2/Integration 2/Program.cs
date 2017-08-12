using System;
using System.Text;

namespace Integration_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Integration 2";
            Console.Write("Equation: \n");
            int degree = inputInt("Degree = ");
            Console.WriteLine();

            Monomial[] function = new Monomial[degree];

            for (int i = 0; i <= degree - 1; i++ )
            {
                function[i] = new Monomial(degree - (i + 1), inputDouble("Coefficient = "));
            }

            Console.WriteLine();

            Console.Write("f(x) = ");

            for (int i = 0; i <= degree - 1; i++ )
            {
                if (i == 0)
                    Console.Write(function[i].ToString());
                else
                    Console.Write(" + " + function[i].ToString());
            }

            Console.WriteLine("\nIntegration:\n");

            double lower = inputDouble("Lower")

            Console.ReadKey(true);
        }

        static double inputDouble(string prompt)
        {
            string inputString = "";
            double value = 0.0;
            do
            {
                Console.Write(prompt);
                inputString = Console.ReadLine();
                if (double.TryParse(inputString, out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid.");
                    continue;
                }
            }
            while (true);
        }
        static int inputInt(string prompt)
        {
            string inputString = "";
            int value = 0;
            do
            {
                Console.Write(prompt);
                inputString = Console.ReadLine();
                if (int.TryParse(inputString, out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid.");
                    continue;
                }
            }
            while (true);
        }
    }

        public class Monomial
        {
            public Monomial(int exponentIn, double coefficientIn)
            {
                exponent = exponentIn;
                coefficient = coefficientIn;
            }

            public int exponent;
            public double coefficient;

            public override string ToString()
            { 
                return coefficient.ToString() + "x^" + exponent.ToString();
            }
        }
}
