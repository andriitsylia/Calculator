using System;
using System.Collections.Generic;
using Calculator.Models;
using Calculator.Services;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the expression: ");
            MathExpression expression = new MathExpression(Console.ReadLine());
            Console.WriteLine(expression.Expression);
            _ = ConvertToTokens.Convert(expression);
        }
    }
}
