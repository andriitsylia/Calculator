using System;
using System.Collections.Generic;
using Calculator.Models;
using Calculator.Services;
using Calculator.Interfaces;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IExpressionReader readFromConsole = new ReadExpressionFromConsole();
            MathExpression expression = readFromConsole.Read();

            //_ = new SimpleCalculator().Calculate(expression);
            ParseExpressionWithBrackets pewb = new ParseExpressionWithBrackets();
            pewb.Parse(expression);

            IExpressionPrinter printToConsole = new PrintExpressionToConsole();
            printToConsole.Print(expression);
        }
    }
}
