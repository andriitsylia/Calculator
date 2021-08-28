using Calculator.Services;
using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the calculator\'s mode:");
            Console.WriteLine("1. + - * /, Console.");
            Console.WriteLine("2. + - * / ( ), File.");
            Console.Write("> ");

            if (int.TryParse(Console.ReadLine(), out int calculatorMode))
            {
                if (calculatorMode == 1 || calculatorMode == 2)
                {
                    Worker worker = new();
                    worker.Run(calculatorMode);
                }
                else
                {
                    Console.WriteLine("You made a wrong choice.");
                }
            }
        }
    }
}
