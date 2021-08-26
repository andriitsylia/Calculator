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
            Console.WriteLine("Choose the calculator\'s mode:");
            Console.WriteLine("1. +-*/, Console.");
            Console.WriteLine("2. +-*/(), File.");
            Console.Write("> ");
            
            int calculatorMode = int.Parse(Console.ReadLine());
            IExpressionReader expressionReader;
            IExpressionPrinter expressionPrinter;
            List<MathExpression> expressions;

            if (calculatorMode == 1)
            {
                expressionReader = new ReadExpressionFromConsole();
                expressions = (List<MathExpression>)expressionReader.Read();
                
                expressionPrinter = new PrintExpressionToConsole();
                
                foreach (MathExpression expression in expressions)
                {
                    _ = new SimpleCalculator().Calculate(expression);

                    expressionPrinter.Print(expression);
                }
            }
            else if (calculatorMode == 2)
            {
                Console.Write("Enter file name: ");
                string fileName = Console.ReadLine();

                IExpressionReader readFromConsole = new ReadExpressionFromFile(fileName);
                expressions = (List<MathExpression>)readFromConsole.Read();
                
                expressionPrinter = new PrintExpressionToConsole();
                ParseExpressionWithBrackets pewb = new ParseExpressionWithBrackets();

                foreach (MathExpression expression in expressions)
                {
                    pewb.Parse(expression);

                    expressionPrinter.Print(expression);
                    //Console.WriteLine(expression.Expression);
                }
            }
            else
            {
                Console.WriteLine("You made a wrong choice.");
            }

        }
    }
}
