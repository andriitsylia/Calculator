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
            Worker worker = new();

            switch (Console.ReadLine())
            {
                case "1":
                    worker.Run(1);
                    break;
                case "2":
                    worker.Run(2);
                    break;
                default:
                    Console.WriteLine("You made a wrong choice.");
                    break;
            }
        }
    }
}
