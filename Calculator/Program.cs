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
            ExpressionValidator validator = new ExpressionValidator();

            if (calculatorMode == 1)
            {
                expressionReader = new ReadExpressionFromConsole();
                expressions = (List<MathExpression>)expressionReader.Read();
                
                expressionPrinter = new PrintExpressionToConsole();
                
                foreach (MathExpression expression in expressions)
                {
                    if (validator.Validate(expression))
                    {
                        _ = new SimpleCalculator().Calculate(expression);
                    }
                    //expressionPrinter.Print(expression);
                }
                expressionPrinter.Print(expressions);
            }
            else if (calculatorMode == 2)
            {
                Console.Write("Enter source file name: ");
                string sourceFileName = Console.ReadLine();
                Console.Write("Enter destination file name: ");
                string destinationFileName = Console.ReadLine();

                IExpressionReader readFromConsole = new ReadExpressionFromFile(sourceFileName);
                expressions = (List<MathExpression>)readFromConsole.Read();
                
                expressionPrinter = new PrintExpressionToConsole();
                ParseExpressionWithBrackets pewb = new ParseExpressionWithBrackets();

                foreach (MathExpression expression in expressions)
                {
                    if (validator.Validate(expression))
                    {
                        pewb.Parse(expression);
                    }
                    //expressionPrinter.Print(expression);
                }
                expressionPrinter.Print(expressions);
            }
            else
            {
                Console.WriteLine("You made a wrong choice.");
            }

        }
    }
}
