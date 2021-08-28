using Calculator.Interfaces;
using Calculator.Models;
using System;
using System.Collections.Generic;

namespace Calculator.Services
{
    public class ReadExpressionFromConsole : IExpressionReader
    {
        public IEnumerable<SourceExpression> Read()
        {
            Console.Write("Enter the expression: ");
            SourceExpression sourceExpression = new(Console.ReadLine());
            List<SourceExpression> sourceExpressions = new() { sourceExpression };
            return sourceExpressions;
        }
    }
}
